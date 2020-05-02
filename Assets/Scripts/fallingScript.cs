using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class fallingScript : MonoBehaviour
{
    public Transform tr;
    public Rigidbody rb;
    private bool fall = false;
    public float fallSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fall)
            {
                tr.position = tr.position - new Vector3(0, fallSpeed, 0);
            }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            //fall = true;
            print("trigger");
            rb.AddForce(0, -1 * fallSpeed, 0);
            rb.useGravity = true;
        }
    }
}
