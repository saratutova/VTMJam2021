using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : Manager<AudioManager>
{
    [SerializeField] private AudioSource _main = default;
    [SerializeField] private List<Clip> _clips;

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
            if (_main.isPlaying)
            {
                _main.Stop();
            }
            _main.clip = clip.clip;
            _main.Play();
        }
        else
        {
            //
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