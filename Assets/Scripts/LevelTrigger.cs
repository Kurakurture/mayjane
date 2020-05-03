﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    LevelManager lm;

    private void Awake()
    {
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter(Collider trigger)
    {
        characterController player = trigger.gameObject.GetComponent<characterController>();
        if (trigger.gameObject.tag == "player" && player.active == true)
        {
            lm.pickLevel();
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
