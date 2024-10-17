using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    private int _selectedObject = 0;

    public event Action<Line> CoreSelected;
    public event Action ButtonSelected;

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
                    CoreSelected?.Invoke(component);
                }
                else if(raycastHit.collider.TryGetComponent(out AttackButton _))
                {
                    ButtonSelected?.Invoke();
                }
            }
        }
    }
}
