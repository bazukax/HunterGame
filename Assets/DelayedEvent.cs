using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;
public class DelayedEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent OnFinished;
    void Start()
    {
        Invoke("DelayedChangeScene", 7);
    }

    void DelayedChangeScene()
    {
        OnFinished.Invoke();
    }
}
