using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
   // public Slider healthBar;
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
     //   healthBar.value = RemainingHealth;
        if (RemainingHealth <= 0)
        {
            GameOver();
        }
        if (RemainingHealth > MaximumHealth)
            RemainingHealth = MaximumHealth;
    }

    private void GameOver()
    {
        switcher.GameOver();
    }
}
