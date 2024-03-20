using System;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : Enemy
{
    private readonly string _name = "Slime";
    private readonly float _health = 100.0f;
    private readonly float _takenDamage = 10.0f;
    private readonly float _maxHealth = 100.0f;


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
        base.TakeDamage();
        Debug.Log(_name + " has attacked.");
    }
    
}
