using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotateObj : GameAction
{
    [SerializeField] private Transform _spriteObj = default;
    [SerializeField] private Vector3 _position = default;
    [SerializeField] private Vector3 _rotation = default;

    protected override void DoAction()
    {
        base.DoAction();

        _spriteObj.position = _position;
        _spriteObj.rotation = Quaternion.Euler(_rotation);
    }
}
