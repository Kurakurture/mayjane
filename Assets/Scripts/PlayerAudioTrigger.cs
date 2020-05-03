using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioTrigger : MonoBehaviour
{
    AudioSource player;   
    bool isDelay = false;

    void Awake()
    {
        player = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            if (!isDelay)
                player.PlayDelayed(Random.Range(0.05f, 0.25f));
                StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {   
        if (isDelay)
            yield break;
        isDelay = true;
        yield return new WaitForSeconds(0.3f);
        isDelay = false;
    }
}
