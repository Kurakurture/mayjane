using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamePlayController : MonoBehaviour
{
    public List<characterController> players;
    public Text scoreText;
    public GameObject charCamera;

    private void Start()
    {
        if (players.Count < 1)
            AddPlayerToList(GameObject.Find("character"));

        charCamera = GameObject.Find("Main Camera");
    }

    public void AddPlayerToList(GameObject _player)
    {
        var controller = _player.GetComponent<characterController>();
        players.Add(controller);

        for (int a = 0; a < players.Count; a++)
        {
            
        }
    }

    public static void SetNewPlayerForCamera()
    {
    }
}
