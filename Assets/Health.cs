using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float RemainingHealth { get; set; }
    public float MaximumHealth { get; private set; }
    public int Difficulty { get; set; }
    private GameSwitcher switcher;

    [SerializeField] private float maxHealth;
    
    public static Health Instance { get; private set; }
    void Awake()
    {
        RemainingHealth = maxHealth;
        MaximumHealth = maxHealth;
        Difficulty = 0;
        Instance = this;
    }

    void Start()
    {
        switcher = GetComponent<GameSwitcher>();
    }

    void Update()
    {
        if (RemainingHealth <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        switcher.GameOver();
    }
}
