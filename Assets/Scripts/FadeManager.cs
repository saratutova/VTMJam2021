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
        var hash = new Hashtable();
        hash.Add("oncomplete", "OnITweenComplete");
        hash.Add("oncompletetarget", gameObject);
        hash.Add("time", time);
        hash.Add("color", color);

        iTween.ColorTo(_curtain.gameObject, hash);
        //iTween.FadeTo(_curtain.gameObject, 0f, 5f);// iTween.Hash("alpha", 0f, "time", 1f, "easetype", "linear"));
        //iTween.ColorTo(gameObject, iTween.Hash("color", color, "time", time, "easetype", "linear"));
    }

    public void FadeIn(float time)
    {
        var colorTo = new Color(_curtain.color.r, _curtain.color.g, _curtain.color.b, 1);
        iTween.ColorTo(_curtain.gameObject, colorTo, time);
    }

    public void FadeOutCompletly()
    {
        _curtain.color = new Color(1, 1, 1, 0);
    }

    public void OnITweenComplete()
    {
        FadeEnded.Invoke();
        FadeEnded.RemoveAllListeners();
    }
}
