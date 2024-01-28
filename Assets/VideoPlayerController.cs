using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
public class VideoPlayerController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private UnityEvent OnFinished;

    void Start()
    {

        // Register the method to be called when the video is finished
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    // Method to be called when the video finishes
    void OnVideoFinished(VideoPlayer vp)
    {
        videoPlayer.loopPointReached -= OnVideoFinished;
        OnFinished.Invoke();
    }
}
