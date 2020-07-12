﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid2 : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb2d;
    private bool store;
    private Vector2  velocity;
    private float rotaton;
    // Start is called before the first frame update
    void Start()
    {
        store = true;
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (Random.Range(1, 3) == 1)
        {
            animator.SetBool("purple", true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.isPlaying)
        {
            if (!store)
            {
                rb2d.velocity = velocity;
                store = true;
            }
        }

        if (!GameState.isPlaying)
        {
            if (store)
            {
                velocity = rb2d.velocity;
                store = false;
            }
            rb2d.velocity = Vector2.zero;
            rb2d.angularVelocity = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "Ship")
        {
            hitInfo.SendMessage("SpawnFires", gameObject.transform);
            Destroy(gameObject);

        }
        else if(hitInfo.name == "Robot")
        {
            hitInfo.SendMessage("DetractPoints", 15);
            Destroy(gameObject);


        }
    }
}
