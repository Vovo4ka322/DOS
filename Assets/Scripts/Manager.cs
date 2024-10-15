using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private CoreSelector _selector;
    [SerializeField] private Clip _clip;
    [SerializeField] private CoreSpawner _spawner;
    [SerializeField] private List<Line> _placesForSeat;

    private List<Queue<Core>> _cores = new();

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

            Physics.IgnoreCollision(core.Collider, line.Collider);

            core.RemoveRigidbody();

            StartCoroutine(SpawnOneCore(lineIndex));

            _clip.Add(core);

            _clip.FindMatch();
        }
    }

    private IEnumerator SpawnOneCore(int lineIndex)
    {
        yield return new WaitForSeconds(0.7f);

        _cores[lineIndex].Enqueue(_spawner.Spawn(_placesForSeat[lineIndex].GetPlaces[0].position));
    }
}
