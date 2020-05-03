using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamePlayController : MonoBehaviour
{
    public List<characterController> players;
    public Text scoreText;
    public GameObject charCamera;
    public float rightPoint;
    public int currentCharIndex;

    public LevelManager _lm;

    public int goalScore = 10;

    private void Start()
    {
        if (players.Count < 1)
            AddPlayerToList(GameObject.Find("character"));

        charCamera = GameObject.Find("Main Camera");
    }

    private float speed = 1;
    float _speedTimer;

    private float minSpeed = 0.1f;
    float _minSpeedTimer;

    private void Update()
    {
        _speedTimer += Time.deltaTime;
        _minSpeedTimer += Time.deltaTime;

        if (_speedTimer > speed)
        {
            EverySecondChecker();
            _speedTimer = 0;
        }

        if (_minSpeedTimer > minSpeed)
        {
            EveryMinSecondChecker();
            _minSpeedTimer = 0;
        }
    }

    public void AddPlayerToList(GameObject _player)
    {
        var controller = _player.GetComponent<characterController>();
        players.Add(controller);
    }

    public void EverySecondChecker()
    {
        scoreText.text = string.Format("Collected: {0} / {1}", players.Count.ToString(), goalScore);
        players.RemoveAll(item => item == null);

        if (players.Count >= goalScore)
        {
            SceneManager.LoadScene("EndingScene");
        }

        if (players.Count <= 0)
        {
            SceneManager.LoadScene("FailScene");
        }
    }

    public void EveryMinSecondChecker()
    {
        //rightPoint = players[0].charTransform.position.x;
        MostRightChecker();
    }

    public void MostRightChecker()
    {
        float checkIn = -1000;
        int checkIndex = 0;

        for (int a = 0; a < players.Count; a++)
        {
            if (players[a].charTransform.position.x > checkIn)
            {
                var pluyer = players[a];
                pluyer.myIndex = a;

                checkIn = players[a].charTransform.position.x;
                checkIndex = a;
            }
        }
       // _lm.player = players[currentCharIndex].gameObject;
        currentCharIndex = checkIndex;
        rightPoint = checkIn;
    }
}
