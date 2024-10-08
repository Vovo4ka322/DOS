using UnityEngine;

[System.Serializable]
public class DataAppropriator
{
    [SerializeField] private Material _material;
    [SerializeField] private int _value;

    public Material Material => _material;

    public int Value => _value;
}
