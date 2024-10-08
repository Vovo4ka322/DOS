using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstClipWall : MonoBehaviour
{
    public event Action<Core> Finished;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Core core))
        {
            Finished?.Invoke(core);
        }
    }
}
