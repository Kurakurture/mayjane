﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public Rigidbody charRigidbody;
    public Collider charCollider;
    public Transform charTransform;
    public bool active = false;
    public Vector3 foreceVector;
    public float forceY;
    public float randomForceY;
    public float forceX;
    public float randomForceX;
    public Material[] charMaterials;
    public ParticleSystem effect;

    public gamePlayController gamePlayController;

    void Start()
    {
        charTransform = this.transform;
        gamePlayController = GameObject.Find("GameplayController").GetComponent<gamePlayController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
            active = true;
    }

    void Update()
    {
        if (!active)
        {
            charRigidbody.useGravity = false;
            effect.Play(false);
        }
        else
        {
            charRigidbody.useGravity = true;
            effect.Play(true);
        }

        if (Input.GetKeyDown("space"))
            CharacterJump();
    }

    void CharacterJump()
    {
        Vector3 _force = foreceVector;
        _force.y += forceY + Random.Range(0f,randomForceY);
        _force.x += forceX + Random.Range(0f,randomForceX);

        if (active)
        {
            charRigidbody.AddForce(_force);
        }
    }
}
