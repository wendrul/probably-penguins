using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLauncher : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float crashDistance;
    [SerializeField] private float minimumSpawnDelay;
    [SerializeField] private float maximumSpawnDelay;
    [SerializeField] private GameObject asteroidPrefab;

    private List<GameObject> asteroids;
    private float timeSinceLastAsteroid;
    private float nextAsteroidDelay;

    [SerializeField] private Transform bottomRight;
    [SerializeField] private Transform topLeft;
    [SerializeField] private float shieldSize;
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private Animator mouseAnimator;
    [SerializeField] private float asteroidDamage;
    [SerializeField] private float healthRegenPerSec;
    [SerializeField] private Transform mouse;


    void Start()
    {
        timeSinceLastAsteroid = 0;
        nextAsteroidDelay = 0;
        asteroids = new List<GameObject>();
    }


    public void Loop()
    {
        LoopAsteroids();
        HealthRegen();
        bool normalAsteroid = true;
        timeSinceLastAsteroid += Time.deltaTime;
        if (normalAsteroid)
        {
            if (timeSinceLastAsteroid > nextAsteroidDelay)
            {
                timeSinceLastAsteroid = 0;
                nextAsteroidDelay = UnityEngine.Random.Range(minimumSpawnDelay, maximumSpawnDelay);

                float x = UnityEngine.Random.Range(topLeft.position.x, bottomRight.position.x);
                float y = UnityEngine.Random.Range(topLeft.position.y, bottomRight.position.y);
                GameObject asteroid = Instantiate(asteroidPrefab, new Vector3(x, y), asteroidPrefab.transform.rotation, this.transform);
                asteroids.Add(asteroid);
            }
        }
        CheckAsteroidCollision();

    }

    private void HealthRegen()
    {
        if (Health.Instance.RemainingHealth < Health.Instance.MaximumHealth)
            Health.Instance.RemainingHealth += Time.deltaTime * healthRegenPerSec;
        if (Health.Instance.RemainingHealth > Health.Instance.MaximumHealth)
            Health.Instance.RemainingHealth = Health.Instance.MaximumHealth;
    }

    private void LoopAsteroids()
    {
        foreach (GameObject asteroid in asteroids)
        {
            asteroid.GetComponent<Asteroid>().Loop();
        }
    }

    private void CheckAsteroidCollision()
    {
        for (int i = asteroids.Count - 1; i >= 0; i--)
        {
            if (asteroids[i].GetComponent<Asteroid>().distanceFromShip < crashDistance)
            {
                Hit(asteroids[i]);
            }
        }
    }

    private void Hit(GameObject asteroid)
    {
        float destructDelay = 0.4f;

        Vector3 diff = mouse.position - asteroid.transform.position;
        diff.z = 0;
        float shieldDistance = diff.magnitude;
        if (shieldDistance > shieldSize)
        {
            TakeDamage();
            AudioManager.Instance.PlaySFX(GameAssets.i.shipHitAsteroid, 0.20f);
            DestroyAsteroidFail(asteroid, destructDelay);
        }
        else
        {
            TallyScore();
            AudioManager.Instance.PlaySFX(GameAssets.i.shieldBlockAsteroid, 2f);
            DestroyAsteroidSuccess(asteroid, 0f);
        }
    }

    private void TallyScore()
    {
    }

    private void DestroyAsteroidSuccess(GameObject asteroid, float destructDelay)
    {
        mouseAnimator.SetTrigger("shield");
        Destroy(asteroid, destructDelay);
        asteroids.Remove(asteroid);
    }

    private void DestroyAsteroidFail(GameObject asteroid, float destructDelay)
    {
        asteroid.GetComponent<Asteroid>().Anim.SetBool("crash", true);
        StartCoroutine(cameraShake.Shake(.15f, .4f));
        Destroy(asteroid, destructDelay);
        asteroids.Remove(asteroid);
    }

    private void TakeDamage()
    {
        Health.Instance.RemainingHealth -= asteroidDamage;
    }
}
