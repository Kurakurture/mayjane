using System.Collections;
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

    public Animation anim;

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

    private void OnCollisionEnter(Collision other)
    {
        anim.Stop();
    }

    private void OnCollisionExit(Collision other)
    {
        anim.Play();
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

        if (other.tag == "scaleBig")
        {
            charTransform.localScale = new Vector3(charTransform.localScale.x * 1.7f, charTransform.localScale.y * 1.7f, charTransform.localScale.z * 1.7f);
        }

        if (other.tag == "scaleSmall")
        {
            charTransform.localScale = new Vector3(charTransform.localScale.x * 0.7f, charTransform.localScale.y * 0.7f, charTransform.localScale.z * 0.7f);
        }

        if (other.tag == "scaleAllSmall")
        {
            for (int a = 0; a < _players.Count; a++)
            {
                var currentChar = _players[a];
                currentChar.charTransform.localScale = new Vector3(currentChar.charTransform.localScale.x * 0.7f, currentChar.charTransform.localScale.y * 0.7f, currentChar.charTransform.localScale.z * 0.7f);
            }
            other.enabled = false;
        }

        if (other.tag == "scaleAllBig")
        {
            for (int a = 0; a < _players.Count; a++)
            {
                var currentChar = _players[a];
                currentChar.charTransform.localScale = new Vector3(currentChar.charTransform.localScale.x * 1.7f, currentChar.charTransform.localScale.y * 1.7f, currentChar.charTransform.localScale.z * 1.7f);
            }
            other.enabled = false;
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

        if (charRigidbody.velocity.x < 0)
        {
            charRigidbody.AddForce(new Vector3(0, -myForce.x / 2, 0));
        }

        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
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

        if (Input.GetKey("space") || Input.GetMouseButton(0))
        {
            if (_speedTimer > speed)
            {

                CharacterForce();
                _speedTimer = 0;
            }
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

        if (charTransform.position.x > _players[0].charTransform.position.x + 5)
        {
            _force.x -= forceX;
            charRigidbody.AddForce(_force);
        }

        if (charTransform.position.x < _players[0].charTransform.position.x - 5)
        {
            _force.x += forceX;
            charRigidbody.AddForce(_force);
        }
    }
}
