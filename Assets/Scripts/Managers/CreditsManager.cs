using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreditsManager : Manager<CreditsManager>
{
    [HideInInspector] public UnityEvent CreditsEnded = new UnityEvent();
    [SerializeField] private RectTransform _text;
    [SerializeField] private GameObject _all;

    private Vector3 _originalPosition = default;

    public void SetActive(bool active)
    {
        _all.SetActive(active);
        if (active)
        {
            Animate();
        }
    }

    private void Animate()
    {
        if (_originalPosition == default)
        {
            _originalPosition = _text.transform.position;
        }
        _text.transform.position = _originalPosition;

        var hash = new Hashtable();
        hash.Add("oncomplete", "OnITweenComplete");
        hash.Add("oncompletetarget", gameObject);
        hash.Add("time", 40);
        hash.Add("amount", new Vector3(0, 70, 0));
        hash.Add("easetype", iTween.EaseType.linear);

        iTween.MoveBy(_text.gameObject, hash);
    }

    public void OnITweenComplete()
    {
        CreditsEnded.Invoke();
        CreditsEnded.RemoveAllListeners();
    }
}
