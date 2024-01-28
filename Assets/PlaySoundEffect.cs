using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public void PlayEffect()
    {
        source.PlayOneShot(clip);
    }
}
