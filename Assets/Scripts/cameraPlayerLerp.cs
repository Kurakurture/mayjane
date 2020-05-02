using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPlayerLerp : MonoBehaviour
{
    public characterController player;
    public Transform selfTransform;
    public float lerpSpeed;
    private List<characterController> _players;

    private float playerX;
    private float playerY;

    public gamePlayController gamePlayController;

    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("character").GetComponent<characterController>();
        }
        gamePlayController = GameObject.Find("GameplayController").GetComponent<gamePlayController>();
    }

    void Update()
    {
        _players = gamePlayController.players;
        int notNull = _players.FindIndex(item => item != null);
        player = _players[notNull];

        playerX = player.charTransform.position.x;
        playerY = player.charTransform.position.y;

        //_players.RemoveAll(item => item == null);

        selfTransform.position = new Vector3(Mathf.Lerp(selfTransform.position.x, playerX, lerpSpeed), Mathf.Lerp(selfTransform.position.y, playerY, lerpSpeed), selfTransform.position.z);
    }
}
