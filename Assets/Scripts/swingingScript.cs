using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swingingScript : MonoBehaviour
{
    public Transform tr;
    public Rigidbody rb;
    public float torque = 10;
    public float rotatingSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb.maxAngularVelocity = rotatingSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddTorque(0, 0, torque);
        print(rb.rotation);

        //if (tr.rotation.)
    }
}
