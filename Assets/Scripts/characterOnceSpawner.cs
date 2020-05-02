using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterOnceSpawner : MonoBehaviour
{
    public GameObject playerExample;
    public gamePlayController gamePlayController;
    public GameObject parentObject;

    // Start is called before the first frame update
    void Start()
    {
        gamePlayController = GameObject.Find("GameplayController").GetComponent<gamePlayController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        CreateNewPlayer(this.transform);
        Destroy(parentObject);
    }


    private void CreateNewPlayer(Transform _position)
    {
        var _gameoject = Instantiate(playerExample, new Vector3(_position.position.x,_position.position.y,_position.position.z), Quaternion.identity);
        var _controller = _gameoject.GetComponent<characterController>();
        _controller.active = true;

        gamePlayController.players.Add(_controller);
    }
}
