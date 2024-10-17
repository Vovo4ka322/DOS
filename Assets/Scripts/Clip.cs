using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clip : MonoBehaviour
{
    [SerializeField] private CoreMerger _merger;
    [SerializeField] private List<Core> _cores;
    [SerializeField] private List<Transform> _placesForSeat;

    private int _maxQuantity = 6;

    public bool IsFullQuantity => _cores.Count == _maxQuantity;

    public void Add(Core core)
    {
        _cores.Add(core);
        Add();
    }

    public void FindMatch()
    {
        _merger.Merge(_cores);
        Add();
    }

    public void RemoveFirstElement(Vector3 target)
    {
        _cores[0].Move(target);

        //if (_cores.Count > 0)
        //    _merger.DeleteCore(_cores, _cores[0]);
    }



    private void Add()
    {
        List<Transform> places = new(_cores.Count);

        for (int i = 0; i < _cores.Count; i++)
        {
            places.Add(_placesForSeat[i]);
        }

        for (int i = 0; i < _cores.Count; i++)
        {
            _cores[i].transform.position = places[places.Count - 1 - i].transform.position;
        }
    }
}
