using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoreMerger : MonoBehaviour
{
    [SerializeField] private Clip _clip;
    [SerializeField] private CoreSpawner _spawner;
    [SerializeField] private Transform _spawnPosition;

    private int _greenCoreValue = 1;
    private int _blueCoreValue = 2;
    private int _redCoreValue = 3;
    private int _yellowCoreValue = 4;

    public void Merge(List<Core> cores)
    {
        for (int i = 0; i < cores.Count - 1; i++)
        {
            if (cores[i].Value == cores[i + 1].Value)
            {
                if (cores[i].Value == _greenCoreValue)
                {
                    DestroyAndRemoveCore(cores);
                    _clip.Add(_spawner.Spawn(_blueCoreValue, _spawnPosition.position));
                }
                else if (cores[i].Value == _blueCoreValue)
                {
                    DestroyAndRemoveCore(cores);
                    _clip.Add(_spawner.Spawn(_redCoreValue, _spawnPosition.position));
                }
                else if (cores[i].Value == _redCoreValue)
                {
                    DestroyAndRemoveCore(cores);
                    _clip.Add(_spawner.Spawn(_yellowCoreValue, _spawnPosition.position));
                }
                else if (cores[i].Value == _yellowCoreValue)
                {
                    DestroyAndRemoveCore(cores);
                }
            }
        }
    }

    private void DestroyAndRemoveCore(List<Core> cores)
    {
        for (int i = 0; i < cores.Count - 1; i++)
        {
            Destroy(cores[i].gameObject);
            Destroy(cores[i + 1].gameObject);
            cores.Remove(cores[i]);
            cores.Remove(cores[i]);
        }
    }
}
