using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterOnceSpawner : MonoBehaviour
{
    public GameObject playerExample;
    public gamePlayController gamePlayController;
    public GameObject parentObject;
    private List<characterController> _players;

    void Start()
    {
        gamePlayController = GameObject.Find("GameplayController").GetComponent<gamePlayController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        CreateNewPlayer(this.transform);
        
    }

    private void CreateNewPlayer(Transform _position)
    {
         _players = gamePlayController.players;
         var mainPlayer = _players[0];
        Rigidbody _mainplayerRigidbody = mainPlayer.charRigidbody;

        var _gameoject = Instantiate(playerExample, new Vector3(_position.position.x, _position.position.y, _position.position.z), Quaternion.identity);
        var _controller = _gameoject.GetComponent<characterController>();
        _controller.active = true;
        _controller.charRigidbody.velocity = _mainplayerRigidbody.velocity;

        gamePlayController.players.Add(_controller);
        Destroy(parentObject);
        this.enabled = false;
    }
}
