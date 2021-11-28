using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Manager<AudioManager>
{
    [SerializeField] private AudioSource _main = default;
    [SerializeField] private List<Clip> _clips;

    private AudioClip nextClip = default;
    float currentVolume = 1;

    public void PlayClip (string clipName)
    {
        var clip = _clips.FirstOrDefault(x => x.clip.name.Equals(clipName));
        if (clip == default)
        {
            Debug.LogError($"Couldn't find a clip: {clipName}");
            return;
        }
        if (clip.isTheme)
        {
            nextClip = clip.clip;

            if (_main.isPlaying)
            {
                SetITween(0);
            }
            else
            {
                OnITweenFinished();
            }
        }
        else
        {
            _main.PlayOneShot(clip.clip);
        }
    }

    private void SetITween(float volume)
    {
        var hash = new Hashtable();
        hash.Add("volume", volume);
        hash.Add("time", 1f);
        hash.Add("oncomplete", "OnITweenFinished");
        hash.Add("oncompletetarget", gameObject);
        iTween.AudioTo(gameObject, hash);
    }

    public void OnITweenFinished()
    {
        if (nextClip != default)
        {
            _main.Stop();
            _main.clip = nextClip;
            _main.Play();
            SetITween(currentVolume);
            nextClip = default;
        }
        else
        {

        }
    }

    public void StopAudio()
    {

    }
}

[System.Serializable]
public class Clip
{
    public AudioClip clip;
    public bool isTheme;
}