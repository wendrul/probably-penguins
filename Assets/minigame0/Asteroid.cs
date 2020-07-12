using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer spriteRenderer;
    public Animator Anim { get; private set; }
    public float distanceFromShip { private set; get; }
    
    [SerializeField] private float startingDistanceFromShip;
    [SerializeField] private float speed;
    [SerializeField] private float startingScale;
    [SerializeField] private float endingScale;
    [SerializeField] private float maxRotationSpeed;
    [SerializeField] private float appearVolume;

    private float rotateSpeed;

    void Start()
    {
        AudioManager.Instance.PlaySFX(GameAssets.i.approachingAsteroid, appearVolume);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();
        ChooseColor();
        distanceFromShip = startingDistanceFromShip;
        rotateSpeed = RandomGaussian(-maxRotationSpeed, maxRotationSpeed);
        transform.localScale = startingScale * new Vector3(1, 1, 1);
        Vector3 zCorrection = transform.position;
        zCorrection.z = distanceFromShip;
        transform.position = zCorrection;
    }


    // Update is called once per frame
    public void Loop()
    {
        float t = distanceFromShip / startingDistanceFromShip;
        transform.localScale = endingScale * Mathf.Exp(-t * Mathf.Log(endingScale / startingScale)) * new Vector3(1, 1, 1);
        distanceFromShip -= speed * Time.deltaTime;
        Vector3 zCorrection = transform.position;
        if (zCorrection.z > 0)
            zCorrection.z = distanceFromShip;
        transform.position = zCorrection;
        transform.Rotate(rotateSpeed * Time.deltaTime * new Vector3(0,0,1));
    }

    private void ChooseColor()
    {
        int n = UnityEngine.Random.Range(1, 5);
        switch (n)
        {
            case 1:
                Anim.SetBool("green", true);
                break;
            case 2:
                Anim.SetBool("pink", true);
                break;
            case 3:
                Anim.SetBool("purple", true);
                break;
            case 4:
                Anim.SetBool("yellow", true);
                break;
            default:
                break;
        }

    }

    private static float RandomGaussian(float minValue = 0.0f, float maxValue = 1.0f)
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
