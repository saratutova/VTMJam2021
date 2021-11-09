using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeManager : Manager<FadeManager>
{
    [HideInInspector] public UnityEvent FadeEnded = new UnityEvent();
    [SerializeField] private Image _curtain;

    public void FadeInColor(Color color)
    {
        _curtain.color = color;
    }

    public void FadeOut(float time)
    {
        var color = new Color(_curtain.color.r, _curtain.color.g, _curtain.color.b, 0);

        SetAnimation(time, color);
    }

    public void FadeIn(float time)
    {
        var color = new Color(_curtain.color.r, _curtain.color.g, _curtain.color.b, 1);

        SetAnimation(time, color);
    }

    public void FadeOutCompletly()
    {
        _curtain.color = new Color(1, 1, 1, 0);
    }

    public void OnITweenComplete()
    {
        FadeEnded.Invoke();
        FadeEnded.RemoveAllListeners();
        _curtain.raycastTarget = false;
    }

    private void SetAnimation(float time, Color color)
    {
        _curtain.raycastTarget = true;
        iTween.ColorTo(_curtain.gameObject, CreateHashtable(time, color));
    }

    private Hashtable CreateHashtable(float time, Color color)
    {
        var hash = new Hashtable();
        hash.Add("oncomplete", "OnITweenComplete");
        hash.Add("oncompletetarget", gameObject);
        hash.Add("time", time);
        hash.Add("color", color);

        return hash;
    }
}
