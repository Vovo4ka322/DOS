using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Core : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private List<CoreDataAppropriator> _appropriators;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private Coroutine _coroutine;
    private int _minValue = 1;
    private int _maxValue = 4;

    [field: SerializeField] public Collider Collider { get; private set; }

    [field: SerializeField] public int Value { get; private set; }

    public int Damage => _damage;

    private void Awake()
    {
        Value = UnityEngine.Random.Range(_minValue, _maxValue + 1);

        SetData(Value);
    }

    public void Move(Vector3 target)
    {
        transform.position = target;
    }
     
    public void Move(List<Transform> positionsToMove, int currentPoint, Vector3 lastPosition)
    {
        _coroutine = StartCoroutine(MoveToTarget(positionsToMove, currentPoint, lastPosition));
    }

    public void SetData(int value)
    {
        CoreDataAppropriator dataAppropriator = _appropriators.FirstOrDefault(i => i.Value == value);

        if (dataAppropriator != null)
        {
            _renderer.material = dataAppropriator.Material;
            _damage = dataAppropriator.Damage;
        }
    }

    public void RemoveRigidbody() => Destroy(_rigidbody);

    private IEnumerator MoveToTarget(List<Transform> positionsToMove, int currentPoint, Vector3 lastPosition)
    {
        for (float t = 0; t <= 1; t += Time.deltaTime * _speed)
        {
            transform.position = Vector3.Lerp(transform.position, positionsToMove[currentPoint].position, t);

            Vector3 currentPosition = positionsToMove[currentPoint].position;

            if (Vector3.Distance(transform.position, currentPosition) <= 0.01f)
            {
                currentPoint++;
                if (currentPoint >= positionsToMove.Count)
                {
                    Collider.enabled = false;
                    transform.position = lastPosition;

                    if (_coroutine != null)
                        StopCoroutine(_coroutine);

                    Collider.enabled = true;
                }
            }

            yield return null;
        }
    }
}