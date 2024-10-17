using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private Gun _gun;

    public Transform Position => transform;

    private void Update()
    {
        _enemyMovement.Move(_gun.transform);
    }

    private void TakeDamage()
    {
        _health = Mathf.Clamp(_health - _gun.Core.Damage, 0, _maxHealth);
    }

}
