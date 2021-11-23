using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FadeManager : Manager<FadeManager>
{
    public static float breakTime = 1f;
    [HideInInspector] public UnityEvent FadeEnded = new UnityEvent();
    [HideInInspector] public UnityEvent HalfFadeEnded = new UnityEvent();
    [SerializeField] private Image _curtain;

    private Color ColorTransparent => new Color(_curtain.color.r, _curtain.color.g, _curtain.color.b, 0);
    private Color ColorFull => new Color(_curtain.color.r, _curtain.color.g, _curtain.color.b, 1);

    private float _midTime = 0f;

    public void FadeInColor(Color color)
    {
        _curtain.color = color;
    }

    public void FadeOut(float time)
    {
        SetAnimation(time, ColorTransparent);
    }

    public void FadeIn(float time)
    {
        SetAnimation(time, ColorFull);
    }

    public void FadeOutCompletly()
    {
        _curtain.color = ColorTransparent;
    }

    public void FadeBreak(float time)
    {
        _midTime = time / 2;
        var hash = new Hashtable();
        hash.Add("time", _midTime);
        hash.Add("color", ColorFull);
        hash.Add("oncomplete", "OnHalfFadeITweenComplete");
        hash.Add("oncompletetarget", gameObject);
        iTween.ColorTo(_curtain.gameObject, hash);
    }

    public void OnITweenComplete()
    {
        FadeEnded.Invoke();
        FadeEnded.RemoveAllListeners();
        _curtain.raycastTarget = false;
    }

    public void OnHalfFadeITweenComplete()
    {
        HalfFadeEnded.Invoke();
        HalfFadeEnded.RemoveAllListeners();
        iTween.ColorTo(_curtain.gameObject, CreateHashtable(_midTime, ColorTransparent));
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
