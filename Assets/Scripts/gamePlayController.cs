using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamePlayController : MonoBehaviour
{
    public List<characterController> players;
    public Text scoreText;
    public GameObject charCamera;
    public int countOfChars = 0;

    public int goalScore = 10;

    private void Start()
    {
        if (players.Count < 1)
            AddPlayerToList(GameObject.Find("character"));

        charCamera = GameObject.Find("Main Camera");
    }

    [SerializeField] public float speed = 1;
    float _speedTimer;

    private void Update()
    {
        _speedTimer += Time.deltaTime;
        if (_speedTimer < speed)
            return;

        if (_speedTimer > speed)
        {
            EverySecondChecker();
            _speedTimer = 0;
        }
    }

    public void AddPlayerToList(GameObject _player)
    {
        var controller = _player.GetComponent<characterController>();
        players.Add(controller);
    }

    public void EverySecondChecker()
    {
        scoreText.text = string.Format("Collected: {0} / {1}", players.Count.ToString(),goalScore);
        players.RemoveAll(item => item == null);
    }
}
