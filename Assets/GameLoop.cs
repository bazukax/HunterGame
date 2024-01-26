using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public List<GameObject> buttons;
    public GameObject objectToSpawn;
    public float spawnInterval = 5f; // Time interval between spawns in seconds
    public Monster monster;
    public SimpleClickHandler clickHandler;

    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnObject();
            timer = spawnInterval;
        }
    }

    void SpawnObject()
    {
        // Instantiate the objectToSpawn at the current position of the SpawnManager
       GameObject clicky = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        Clicky clickyBtn = clicky.GetComponent<Clicky>();
        clickyBtn.SetClickHandler( clickHandler );
    }

    public void RestartTimer()
    {
        timer = spawnInterval;
    }
}
