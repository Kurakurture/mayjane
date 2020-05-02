using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPlayerLerp : MonoBehaviour
{
    public characterController player;
    public Transform selfTransform;

    // Start is called before the first frame update
    void Start()
    {
        if(player == null){
            player = GameObject.Find("character").GetComponent<characterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null){
            player = GameObject.Find("character").GetComponent<characterController>();
        }
    }
}
