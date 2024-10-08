using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private List<Transform> _placesForSeat;

    [field: SerializeField] public Collider Collider { get; private set; }

    public IReadOnlyList<Transform> GetPlaces => _placesForSeat;
}
