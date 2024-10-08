using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clip : MonoBehaviour
{
    [SerializeField] private Transform _placeForSeat;
    [SerializeField] private List<Core> _cores;
    [SerializeField] private CoreMerger _merger;

    private int _maxQuantity = 6;

    public event Action Found;

    public void Add(Core core)
    {
        _cores.Add(core);
    }

    public void FindMatch()
    {
        _merger.Merge(_cores);
    }

    public bool IsFullQuantity => _cores.Count == _maxQuantity;

    public Transform GetSeatPlace => _placeForSeat;
}
