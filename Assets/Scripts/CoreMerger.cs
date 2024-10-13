using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.UI.GridLayoutGroup;

public class CoreMerger : MonoBehaviour
{
    [SerializeField] private Clip _clip;
    [SerializeField] private CoreSpawner _spawner;
    [SerializeField] private Transform _spawnPosition;

    //private Core _currentCore;
    private int _greenCoreValue = 1;
    private int _blueCoreValue = 2;
    private int _redCoreValue = 3;
    private int _yellowCoreValue = 4;

    public void Merge(List<Core> cores)
    {
        Debug.Log("����� � ����� Merge");
        Debug.Log(cores.Count + " ����� �����");

        foreach (Core core in cores)
        {
            Debug.Log(core.Value + " ���� ���a");
        }

        if (cores.Count < 2)
        {
            return;
        }

        while (CanMerge(cores, out int indexOne, out int indexTwo))
        {
            int color = -1;

            if (cores[indexOne].Value == _greenCoreValue)
            {
                color = _blueCoreValue;
            }
            else if (cores[indexOne].Value == _blueCoreValue)
            {
                color = _redCoreValue;
            }
            else if (cores[indexOne].Value == _redCoreValue)
            {
                color = _yellowCoreValue;
            }

            DeleteCore(cores, cores[indexTwo]);
            DeleteCore(cores, cores[indexOne]);

            cores.Insert(indexOne, _spawner.Spawn(color, _spawnPosition.position));
        }
    }

    private bool CanMerge(List<Core> cores, out int indexOne, out int indexTwo)
    {
        for (int i = 0; i < cores.Count - 1; i++)
        {
            if (cores[i].Value == cores[i + 1].Value)
            {
                indexOne = i;
                indexTwo = i + 1;

                return true;
            }
        }

        indexOne = 0;
        indexTwo = 0;

        return false;
    }

    private void DeleteCore(List<Core> cores, Core core)
    {
        cores.Remove(core);
        Destroy(core.gameObject);
    }
}
