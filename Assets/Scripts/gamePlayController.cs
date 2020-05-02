using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePlayController : MonoBehaviour
{
    public List<characterController> players;
    
    void Start()
    {
        
    }

    void Update()
    {
        players.Add(GameObject.Find("character").GetComponent<characterController>());

    }
}
