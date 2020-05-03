using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swingingScript : MonoBehaviour
{
    public Transform tr;
    public Rigidbody rb;
    public float torque = 10;
    public float rotatingSpeed = 2;
    public float swingAngle = 180;

    // Start is called before the first frame update
    void Start()
    {
        if (rotatingSpeed > 7)
        {
            rotatingSpeed = 7;
        }
        else
        {
            rotatingSpeed = Mathf.Abs(rotatingSpeed);
        }

        rb.maxAngularVelocity = rotatingSpeed;

        SetDirection();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddTorque(0, 0, torque);
        //print(rb.rotation);

        if (tr.rotation.z >= swingAngle/300)
        {
            torque = -1 * torque;
            SetDirection();
        }
        else if (tr.rotation.z <= swingAngle / -300)
        {
            torque = -1 * torque;
            SetDirection();
        }
    }

    void SetDirection()
    {
        //print(tr.rotation.z);
        if (torque >= 0)
        {
            rb.angularVelocity = new Vector3(0, 0, rotatingSpeed);
        }
        else
        {
            rb.angularVelocity = new Vector3(0, 0, -1 * rotatingSpeed);
        }
    }
}
