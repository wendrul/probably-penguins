using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    public float distanceFromShip { private set; get; }
    
    [SerializeField] private float startingDistanceFromShip;
    [SerializeField] private float speed;
    [SerializeField] private float startingScale;
    [SerializeField] private float endingScale;

    private float rotateSpeed;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        distanceFromShip = startingDistanceFromShip;
        rotateSpeed = RandomGaussian(0f, 200f);
        transform.localScale = startingScale * new Vector3(1, 1, 1);
        Vector3 zCorrection = transform.position;
        zCorrection.z = distanceFromShip;
        transform.position = zCorrection;
    }

    // Update is called once per frame
    void Update()
    {
        float t = distanceFromShip / startingDistanceFromShip;
        transform.localScale = endingScale * Mathf.Exp(-t * Mathf.Log(endingScale / startingScale)) * new Vector3(1, 1, 1);
        distanceFromShip -= speed * Time.deltaTime;
        Vector3 zCorrection = transform.position;
        zCorrection.z = distanceFromShip;
        transform.position = zCorrection;
        transform.Rotate(rotateSpeed * Time.deltaTime * new Vector3(0,0,1));
    }
    
    public static float RandomGaussian(float minValue = 0.0f, float maxValue = 1.0f)
    {
        float u, v, S;

        do
        {
            u = 2.0f * UnityEngine.Random.value - 1.0f;
            v = 2.0f * UnityEngine.Random.value - 1.0f;
            S = u * u + v * v;
        }
        while (S >= 1.0f);

        // Standard Normal Distribution
        float std = u * Mathf.Sqrt(-2.0f * Mathf.Log(S) / S);

        // Normal Distribution centered between the min and max value
        // and clamped following the "three-sigma rule"
        float mean = (minValue + maxValue) / 2.0f;
        float sigma = (maxValue - mean) / 3.0f;
        return Mathf.Clamp(std * sigma + mean, minValue, maxValue);
    }
}
