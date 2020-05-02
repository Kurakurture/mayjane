using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPlayerLerp : MonoBehaviour
{
    public characterController player;
    public Transform selfTransform;
    public float lerpSpeed;

    private float playerX;
    private float playerY;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("character").GetComponent<characterController>();
        }


    }

    void Update()
    {
        playerX = player.charTransform.position.x;
        playerY = player.charTransform.position.y;

        if (player == null)
        {
            player = GameObject.Find("character").GetComponent<characterController>();
        }
        else
        {
            selfTransform.position = new Vector3(Mathf.Lerp(selfTransform.position.x, playerX, lerpSpeed), Mathf.Lerp(selfTransform.position.y, playerY, lerpSpeed), selfTransform.position.z);
        }
    }
}
