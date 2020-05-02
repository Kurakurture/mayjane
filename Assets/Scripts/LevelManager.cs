using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float distanceBetweenLevels = 30;
    public GameObject currentLevel;
    public GameObject[] levelPrefab;

    GameObject levelToDestroy;

    public void pickLevel()
    {
        GameObject nextLevel = levelPrefab[Random.Range(0, levelPrefab.Length)];
        loadNewAndDestroyOldLevel(nextLevel);
    }

    void loadNewAndDestroyOldLevel(GameObject nextLevel)
    {
        if (levelToDestroy != null)
            Destroy(levelToDestroy);
        Instantiate(nextLevel, new Vector3(currentLevel.transform.position.x + distanceBetweenLevels, 0, 0), Quaternion.identity);
        levelToDestroy = currentLevel;
        currentLevel = nextLevel;                
    }
}
