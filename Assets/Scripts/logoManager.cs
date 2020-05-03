using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logoManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("space") || Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            goToGame();
    }

    void goToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
