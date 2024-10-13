using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clip : MonoBehaviour
{
    [SerializeField] private Transform _placeForSeat;
    [SerializeField] private CoreMerger _merger;
    [SerializeField] private List<Core> _cores;

    //private Core _core;

    private int _maxQuantity = 6;

    public void Add(Core core)
    {
        _cores.Add(core);
    }

    //public void Add(Core core)
    //{
    //    _core = core;
    //}

    public void FindMatch()
    {
        _merger.Merge(_cores);
    }

    //public void FindMatch()
    //{
    //    _merger.Merge(_core);
    //}

    public bool IsFullQuantity => _cores.Count == _maxQuantity;

    public Transform GetSeatPlace => _placeForSeat;
}
