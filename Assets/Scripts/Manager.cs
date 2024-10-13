using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private CoreSelector _selector;
    [SerializeField] private Clip _clip;
    [SerializeField] private CoreSpawner _spawner;
    [SerializeField] private List<Line> _placesForSeat;
    [SerializeField] private List<Transform> _positionsToMove;
    [SerializeField] private Transform _positionFrontOfClip;
    [SerializeField] private FirstClipWall _firstClipWall;

    private List<Queue<Core>> _cores = new();
    private int _currentPoint = 0;

    private void Awake()
    {
        for (int i = 0; i < _placesForSeat.Count; i++)
        {
            _cores.Add(new Queue<Core>());

            for (int j = _placesForSeat[i].GetPlaces.Count - 1; j >= 0; j--)
            {
                _cores[i].Enqueue(_spawner.Spawn(_placesForSeat[i].GetPlaces[j].position));
            }
        }
    }

    private void OnEnable()
    {
        _selector.Selected += OnRemoved;
    }

    private void OnDisable()
    {
        _selector.Selected -= OnRemoved;
    }

    private void OnRemoved(Line line)
    {
        if (_clip.IsFullQuantity == false)
        {
            int lineIndex = _placesForSeat.IndexOf(line);

            Core core = _cores[lineIndex].Dequeue();

            Debug.Log(core.Value + " значение шара");

            Physics.IgnoreCollision(core.Collider, line.Collider);

            StartCoroutine(SpawnOneCore(lineIndex));

            core.Touched += GuideCore;

            _firstClipWall.CoreFinished += AddCoreInClip;
        }
    }

    private void GuideCore(Core core)
    {
        core.Move(_positionsToMove, _currentPoint, _clip.GetSeatPlace.position);
        core.Touched -= GuideCore;
    }

    private void AddCoreInClip(Core core)
    {
        _firstClipWall.CoreFinished -= AddCoreInClip;
        _clip.Add(core);
        Debug.Log(core.Value + " " + core + " Добавился в клип");
        _clip.FindMatch();
    }

    private IEnumerator SpawnOneCore(int lineIndex)
    {
        yield return new WaitForSeconds(0.7f);

        _cores[lineIndex].Enqueue(_spawner.Spawn(_placesForSeat[lineIndex].GetPlaces[0].position));
    }
}
