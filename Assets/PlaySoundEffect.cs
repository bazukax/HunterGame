using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlaySoundEffect : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    [SerializeField] private UnityEvent OnPlayEvent;
    public void PlayEffect()
    {
        source.PlayOneShot(clip);
        OnPlayEvent.Invoke();
    }
}
