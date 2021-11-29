using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimation : GameAction
{
    [SerializeField] private SpriteRenderer _spriteRenderer = default;
    [SerializeField] private Color _endColor = default;

    protected override void DoAction()
    {
        base.DoAction();
        iTween.Stop(_spriteRenderer.gameObject);
        _spriteRenderer.color = _endColor;
    }
}
