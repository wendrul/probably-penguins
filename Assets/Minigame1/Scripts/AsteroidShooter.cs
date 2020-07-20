using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidShooter : MonoBehaviour
{
    [SerializeField] private GameObject[] firePoints;
    public GameObject asteroidPrefab;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("Robot").transform;
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void StopShooting()
    {
         CancelInvoke();
    }
    public void StartShooting()
    {
        InvokeRepeating("ShootAsteroid", 0.4f, 1.3f);
    }

    private void ShootAsteroid()
    {
        int i = Random.Range(0, 4);

        GameObject asteroid =  Instantiate(asteroidPrefab, firePoints[i].transform.position, firePoints[i].transform.rotation);
        LookAt2D(player.transform.position, asteroid.transform);
        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        rb.velocity = (player.position - asteroid.transform.position).normalized * 6f;

    }

    private void LookAt2D(Vector2 coord, Transform sword)
    {
        // LookAt 2D
        Vector3 target = (Vector3)coord;
        // get the angle
        Vector3 norTar = (target - sword.position).normalized;
        float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
        // rotate to angle
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, angle +90);
        sword.rotation = rotation;
    }

}
