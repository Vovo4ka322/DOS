using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputHandler : MonoBehaviour
{
    [SerializeField] private Selector _selector;
    [SerializeField] private Clip _clip;
    [SerializeField] private CoreFactory _factory;
    [SerializeField] private Gun _gun;
    [SerializeField] private AttackButton _attackButton;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _selector.CoreSelected += OnRemoved;
        _selector.ButtonSelected += OnShoot;
    }

    private void OnDisable()
    {
        _selector.CoreSelected -= OnRemoved;
        _selector.ButtonSelected -= OnShoot;
    }

    private void OnRemoved(Line line)
    {
        if (_clip.IsFullQuantity == false)
        {
            int lineIndex = _factory.PlacesForSeat.IndexOf(line);

            Core core = _factory.Cores[lineIndex].Dequeue();

            Physics.IgnoreCollision(core.Collider, line.Collider);

            core.RemoveRigidbody();

            _coroutine = StartCoroutine(_factory.CreateOneCore(lineIndex));

            _clip.Add(core);

            _clip.FindMatch();
        }
    }

    private void OnShoot()
    {
        _attackButton.PlayAnimation();
        _gun.Shoot();
    }
}
