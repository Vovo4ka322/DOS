using UnityEngine;

[System.Serializable]
public class CoreDataAppropriator
{
    [SerializeField] private Material _material;
    [SerializeField] private int _value;
    [SerializeField] private int _damage;

    public Material Material => _material;

    public int Value => _value;

    public int Damage => _damage;   
}
