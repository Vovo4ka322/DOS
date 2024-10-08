using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreSelector : MonoBehaviour
{
    private int _selectedObject = 0;

    public event Action<Line> Selected;

    private void Update()
    {
        Choose();
    }

    private void Choose()
    {
        if(Input.GetMouseButtonDown(_selectedObject))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if(raycastHit.collider.TryGetComponent(out Line component))
                {
                    Selected?.Invoke(component);
                }
            }
        }
    }
}
