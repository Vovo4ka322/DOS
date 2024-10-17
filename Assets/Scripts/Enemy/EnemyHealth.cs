using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;

    public bool IsDead => _health <= 0;

    public void Lose(int damage)
    {
        _health = Mathf.Clamp(_health - damage, 0, _maxHealth);
    }
}
