using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreSpawner : MonoBehaviour
{
    [SerializeField] private Core _corePrefab;

    public Core Spawn(int value, Vector3 position)
    {
        Core core = CallIPrefab(position);

        core.SetData(value);

        return core;
    }

    public Core Spawn(Vector3 position) => CallIPrefab(position);

    private Core CallIPrefab(Vector3 position) => Instantiate(_corePrefab, position, Quaternion.identity);
}