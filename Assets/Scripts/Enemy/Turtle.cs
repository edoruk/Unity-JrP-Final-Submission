using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : Enemy
{
    private readonly string _name = "Turtle";
    private readonly float _health = 50.0f;
    private readonly float _takenDamage = 20.0f;
    private readonly float _maxHealth = 50.0f;
    
    protected override void Start()
    {
        Name = _name;
        Health = _health;
        TakenDamage = _takenDamage;
        MaxHealth = _maxHealth;
    }

    protected override void Update()
    {
    }

    public override void TakeDamage()
    {
        Health -= _takenDamage;
    }
}
