using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;

    private List<Vector3> _positionsToMove = new();
    private int _currentPoint;
    private Coroutine _coroutine;

    private void Awake()
    {
        _positionsToMove.Add(_targetPosition);
        _positionsToMove.Add(_startPosition);
    }

    public void PlayAnimation()
    {
        _coroutine = StartCoroutine(ChangePosition());
    }

    private IEnumerator ChangePosition()
    {
        for (float t = 0; t <= 1; t += Time.deltaTime * _speed)
        {
            transform.position = Vector3.Lerp(transform.position, _positionsToMove[_currentPoint], t);

            Vector3 currentPosition = _positionsToMove[_currentPoint];

            if (Vector3.Distance(transform.position, currentPosition) <= 0.001f)
            {
                _currentPoint++;

                if (_currentPoint >= _positionsToMove.Count)
                {
                    if (_coroutine != null)
                        StopCoroutine(_coroutine);

                    _currentPoint = 0;
                }
            }

            yield return null;
        }
    }
}
