using UnityEngine;
using System;

public class SimpleClickHandler : MonoBehaviour
{
    // Define the event using Action
    public event Action<KeyCode> OnKeyboardClick;

    private void Update()
    {
        // Check for keyboard input in the Update method
        CheckForKeyboardInput();
    }

    private void CheckForKeyboardInput()
    {
        // Loop through all possible keys
        foreach (KeyCode keyCode in Enum.GetValues(typeof(KeyCode)))
        {
            // Check if the key is pressed down
            if (Input.GetKeyDown(keyCode))
            {
                Debug.Log("click");
                // Notify subscribers about the keyboard click
                NotifySubscribers(keyCode);
            }
        }
    }

    private void NotifySubscribers(KeyCode key)
    {
        // Check if there are any subscribers before notifying
        OnKeyboardClick?.Invoke(key);
    }
}
