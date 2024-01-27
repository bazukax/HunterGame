using System.Collections;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] musicClips;
    public AudioSource audioSource;
    public float fadeDuration = 1.0f;

    private int currentClipIndex = 0;
    private float initialVolume;

    void Start()
    {
        if (audioSource != null)
        {
            // Store the initial volume
            initialVolume = audioSource.volume;
        }
        else
        {
            Debug.LogError("Please assign AudioSource to the script!");
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F12))audioSource.mute = !audioSource.mute;
    }

    // Method to start playing the music
    public void PlayMusic(int index)
    {
        if (musicClips.Length > 0 && audioSource != null)
        {
            if (audioSource.isPlaying)
            {
                // If music is already playing, initiate crossfade to the new clip
                StartCoroutine(CrossfadeToNewClip(index));
            }
            else
            {
                // If no music is playing, play the new clip normally
                audioSource.clip = musicClips[index];
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogError("Please assign music clips and AudioSource to the script!");
        }
    }

    // Method to stop the music
    public void StopMusic()
    {
        audioSource.Stop();
    }

    // Coroutine for crossfading to a new clip
    IEnumerator CrossfadeToNewClip(int newIndex)
    {
        // Set the next clip and start the fade-out
        AudioClip nextClip = musicClips[newIndex];
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Fade out the current clip
            audioSource.volume = Mathf.Lerp(initialVolume, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Switch to the next clip and start the fade-in
        audioSource.clip = nextClip;
        audioSource.Play();

        elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Fade in the next clip
            audioSource.volume = Mathf.Lerp(0f, initialVolume, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure volume is set to the initial volume after the fade-in
        audioSource.volume = initialVolume;
    }
}