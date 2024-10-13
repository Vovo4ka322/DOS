using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstClipWall : MonoBehaviour
{
    public event Action<Core> CoreFinished;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Core core))
        {
            Debug.Log(core.Value + " Докоснулся до стены");
            CoreFinished?.Invoke(core);
        }
    }
}
