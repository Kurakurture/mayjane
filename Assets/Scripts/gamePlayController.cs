﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamePlayController : MonoBehaviour
{
    public List<characterController> players;
    public Text scoreText;
    public GameObject charCamera;
    public int countOfChars = 0;

    private void Start()
    {
        if (players.Count < 1)
            AddPlayerToList(GameObject.Find("character"));

        charCamera = GameObject.Find("Main Camera");
    }

    [SerializeField] public float speed = 1;
    float _speedTimer;

    private void Update()
    {
        _speedTimer += Time.deltaTime;
        if (_speedTimer < speed)
            return;

        if (_speedTimer > speed)
        {
            EverySecondChecker();
            _speedTimer = 0;
        }
        //checkCountOfChars();
    }

    public void AddPlayerToList(GameObject _player)
    {
        var controller = _player.GetComponent<characterController>();
        players.Add(controller);
    }

    public void checkCountOfChars()
    {
        countOfChars = 0;
        for (int a = 0; a < players.Count; a++)
        {
            if (players[a] != null)
                countOfChars++;
        }
    }

    public void EverySecondChecker()
    {
        scoreText.text = players.Count.ToString();
        players.RemoveAll(item => item == null);
    }
}
