using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoreFactory : MonoBehaviour
{
    [SerializeField] private CoreSpawner _spawner;
    [SerializeField] private List<Line> _placesForSeat;

    private List<Queue<Core>> _cores = new();
    private float _timeUntilSpawn = 0.7f;

    public List<Queue<Core>> Cores => _cores;

    public List<Line> PlacesForSeat => _placesForSeat;

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

    public IEnumerator CreateOneCore(int lineIndex)
    {
        yield return new WaitForSeconds(_timeUntilSpawn);

        _cores[lineIndex].Enqueue(_spawner.Spawn(_placesForSeat[lineIndex].GetPlaces[0].position));
    }
}
