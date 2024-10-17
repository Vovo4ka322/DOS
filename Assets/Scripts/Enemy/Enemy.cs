using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyHealth _health;
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private Gun _gun;

    public Transform Position => transform;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("work");

        if(collision.gameObject.TryGetComponent(out Core core))
        {
            Debug.Log("Touched");
            _health.Lose(core.Damage);

            if(_health.IsDead)
                Destroy(gameObject);
        }
    }

    private void Update()
    {
        _enemyMovement.Move(_gun.transform);
    }
}
