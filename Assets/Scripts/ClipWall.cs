using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipWall : MonoBehaviour
{
    public event Action<Core> Touched;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Core core))
        {
            Debug.Log("Шар докоснулся до стены");
            Touched?.Invoke(core);
        }
    }
}
