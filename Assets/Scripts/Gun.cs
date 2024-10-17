using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Core _core;
    [SerializeField] private Clip _clip;
    [SerializeField] private List<Enemy> _enemies;

    public Core Core => _core;

    public void Shoot()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            _clip.RemoveFirstElement(_enemies[i].transform.position);
        }
    }
}
