using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public List<GameObject> buttons;
    public GameObject objectToSpawn;
    public Monster monster;
    public Player player;
    public SimpleClickHandler clickHandler;
    public AudioSource audioSource;
    private float timer;
    public List<ScenarioSegment> segments;
    public int currentSegment = 0;

    public SceneManger sceneManger;
    public Animator monsterAnimator;
    public Animator PlayerAnimator;

    void Start()
    {
        BeginSegment();
    }
    void BeginSegment()
    {
        monsterAnimator.Play("Talk");
        audioSource.PlayOneShot(segments[currentSegment].mainVoiceover);
        Invoke("SpawnClicky", segments[currentSegment].mainVoiceover.length + 0.5f);
    }


    void SpawnClicky()
    {
        GameObject clicky = Instantiate(segments[currentSegment].clicky, transform.position, Quaternion.identity);
        Clicky clickyBtn = clicky.GetComponent<Clicky>();
        clickyBtn.SetClickHandler( clickHandler );
        clickyBtn.SetTarget(monster);
        clickyBtn.SetPlayer(player);
        clickyBtn.SetGameLoop(this);
    }
    public void OnSuccessfulHit()
    {
        Debug.Log("success");
        PlayerAnimator.Play("Hit");
        audioSource.PlayOneShot(segments[currentSegment].getHit);
        if (currentSegment < segments.Count - 1)
        {
            Invoke("SpawnClicky", segments[currentSegment].getHit.length + 0.5f);
            currentSegment++;
        }else
        {
            Invoke("Victory", segments[currentSegment].getHit.length + 0.5f);
        }
        monsterAnimator.Play("GetHit");
    }
    public void OnFailure()
    {
        int rngShitTalk = Random.Range(0, segments[currentSegment].shitTalks.Count);
        audioSource.PlayOneShot(segments[currentSegment].shitTalks[rngShitTalk]);

        if (player.health <= 1)
        {
            Invoke("ChangeScene", segments[currentSegment].shitTalks[rngShitTalk].length + 1f);
        }
        else
        {
            Invoke("SpawnClicky", segments[currentSegment].shitTalks[rngShitTalk].length + 1f);
        }
        monsterAnimator.Play("ShitTalk");

        segments[currentSegment].shitTalks.RemoveAt(rngShitTalk);
       

    }
    void ChangeScene()
    {
            sceneManger.ChangeScene(0);
    }
    void Victory()
    {
        sceneManger.ChangeScene(0);
    }

}
