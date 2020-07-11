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
        InvokeRepeating("ShootAsteroid", 2.0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShootAsteroid()
    {
        int i = Random.Range(0, 4);
        Debug.Log(i);
        GameObject asteroid =  Instantiate(asteroidPrefab, firePoints[i].transform.position, firePoints[i].transform.rotation);
        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        rb.velocity = (player.position - asteroid.transform.position).normalized * 10f;

    }

}
