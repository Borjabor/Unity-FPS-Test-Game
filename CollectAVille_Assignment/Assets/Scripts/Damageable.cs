using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    protected float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public virtual void TakeDamage(float damage, Vector3 hitPos, Vector3 hitNormal)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die(); ;
            PointsManager.TotalPoints++;
        }

        
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    
}
