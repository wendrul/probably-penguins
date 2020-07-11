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

    void Start()
    {
        timeSinceLastAsteroid = 0;
        nextAsteroidDelay = 0;
        asteroids = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
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
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        float shieldDistance = (mousePos - asteroid.transform.position).magnitude;
        print(shieldDistance);
        if (shieldDistance > shieldSize)
        {
            TakeDamage();
            DestroyAsteroidFail(asteroid);
        }
        else
        {
            TallyScore();
            DestroyAsteroidSuccess(asteroid);
        }
    }

    private void TallyScore()
    {
    }

    private void DestroyAsteroidSuccess(GameObject asteroid)
    {
        //play anim
        print("Blocked!");
        Destroy(asteroid);
        asteroids.Remove(asteroid);
    }

    private void DestroyAsteroidFail(GameObject asteroid)
    {
        //play anim
        StartCoroutine(cameraShake.Shake(.15f, .4f));
        print("fail");
        Destroy(asteroid);
        asteroids.Remove(asteroid);
    }

    private void TakeDamage()
    {
    }
}
