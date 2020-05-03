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

    public Vector3 myForce;

    public int heightOfDeath;

    public List<characterController> _players;

    public gamePlayController gamePlayController;

    private float speed = 0.01f;
    float _speedTimer;

    void Start()
    {
        charTransform = this.transform;
        gamePlayController = GameObject.Find("GameplayController").GetComponent<gamePlayController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
            active = true;

        if (other.tag == "destroyer")
        {
            active = false;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        myForce = charRigidbody.velocity;

                /*
                if(charRigidbody.velocity.y>6)
                {
                    charRigidbody.AddForce(new Vector3(0,-myForce.y/3,0));
                }

                if(charRigidbody.velocity.x>4)
                {
                    charRigidbody.AddForce(new Vector3(0,-myForce.x/2,0));
                }
                */

        if (!active)
        {
            charRigidbody.useGravity = false;
            charRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        }
        else
        {
            charRigidbody.useGravity = true;
            charRigidbody.constraints = RigidbodyConstraints.None;
        }

        if (Input.GetKeyDown("space"))
        {
            CharacterJump();
        }

        if (this.transform.position.y <= heightOfDeath)
            Destroy(gameObject);

        if (this.transform.position.y >= Mathf.Abs(heightOfDeath))
            Destroy(gameObject);

        _players = gamePlayController.players;

        _speedTimer += Time.deltaTime;
        if (_speedTimer < speed)
            return;

        if (_speedTimer > speed && Input.GetKey("space"))
        {
            CharacterForce();
            _speedTimer = 0;
        }
    }

    void CharacterJump()
    {
        Vector3 _force = foreceVector;
        _force.y += forceY + Random.Range(0f, randomForceY);
        _force.x += forceX + Random.Range(0f, randomForceX);

        if (active)
        {
            charRigidbody.AddForce(_force);
        }
        PackForce();
    }

    void CharacterForce()
    {
        Vector3 _force = foreceVector;
        _force.y += forceY / 7;
        _force.x += forceX / 4;

        if (active)
        {
            charRigidbody.AddForce(_force);
        }
        PackForce();
    }

    void PackForce()
    {
        Vector3 _force = new Vector3(0, 0, 0);

        var myVector = this.transform.position;
        var goalVector = _players[0].charTransform.position;

        if (charTransform.position.x > _players[0].charTransform.position.x)
        {
            _force.x -= forceX;
            charRigidbody.AddForce(_force);
        }

        if (charTransform.position.x < _players[0].charTransform.position.x)
        {
            _force.x += forceX;
            charRigidbody.AddForce(_force);
        }
    }
}
