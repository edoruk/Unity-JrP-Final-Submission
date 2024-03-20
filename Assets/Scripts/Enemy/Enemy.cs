
using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public string Name;
    public float Health;
    public float TakenDamage;
    public float MaxHealth;

    protected abstract void Start();

    protected abstract void Update();

    public virtual void TakeDamage()
    {
        Health -= TakenDamage;
    }
}
