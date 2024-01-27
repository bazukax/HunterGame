using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{
    // Update is called once per frame
    void Awake()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            ChangeScene(0);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            ChangeScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            ChangeScene(2);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            ChangeScene(3);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            ChangeScene(4);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            ChangeScene(5);
        }
        // Add more conditions for other numpad keys as needed.
    }

    public void ChangeScene(int sceneIndex)
    {
        // Load the scene based on the index.
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogWarning("Scene index is out of range.");
        }
    }
    public void ChangeSceneByCheckpoint()
    {
        int lastCheckPoint = PlayerPrefs.GetInt("checkpoint", 0);
        if (lastCheckPoint == 0)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(1);
        }

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
