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
        InvokeRepeating("ShootAsteroid", 0.1f, 1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShootAsteroid()
    {
        int i = Random.Range(0, 4);

        GameObject asteroid =  Instantiate(asteroidPrefab, firePoints[i].transform.position, firePoints[i].transform.rotation);
        LookAt2D(player.transform.position, asteroid.transform);
        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        rb.velocity = (player.position - asteroid.transform.position).normalized * 4f;

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
