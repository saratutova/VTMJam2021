using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : GameAction
{
    [SerializeField] private SpriteRenderer _spriteRenderer = default;
    [SerializeField] private Sprite _sprite = default;

    protected override void DoAction()
    {
        base.DoAction();
        _spriteRenderer.sprite = _sprite;
    }
}
