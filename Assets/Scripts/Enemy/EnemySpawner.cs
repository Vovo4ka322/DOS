using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemyPrefabs;
    [SerializeField] private Transform _spawnPoint;

    private void Start()
    {
        //Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _enemyPrefabs.Count;)
        {
            Enemy enemy = Instantiate(_enemyPrefabs[i], _spawnPoint.position, Quaternion.identity);

            i++;

            return;
        }
    }
}
