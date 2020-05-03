using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float currentLevelWidth = 30;
    public int levelsCompleted = 0;
    public int IncreaseDifficultyAfterLevels = 5;
    public int currentLevelDifficulty = 1;
    public GameObject currentLevel;
    public GameObject creature;
    public GameObject[] levelPrefab;
    public GameObject[] levelForDiff1Only;
    public GameObject[] levelForDiff2Only;
    public GameObject[] levelForDiff3Only;


    GameObject levelToDestroy;

    public void pickLevel()
    {
        List<GameObject> list = new List<GameObject>();
            foreach (GameObject level in levelPrefab)
                list.Add(level);

        if (currentLevelDifficulty == 1 && levelForDiff1Only == null)
        {
            foreach (GameObject level in levelForDiff1Only)
                list.Add(level);
        }
        else if (currentLevelDifficulty == 2 && levelForDiff2Only == null)
        {
            foreach (GameObject level in levelForDiff2Only)
                list.Add(level);
        }
        else if (currentLevelDifficulty == 3 && levelForDiff3Only == null)
        {
            foreach (GameObject level in levelForDiff3Only)
                list.Add(level);
        }
        GameObject nextLevel = list[Random.Range(0, list.Count)];
        loadNewAndDestroyOldLevel(nextLevel);
        SetLevelDifficulty();
    }

    void loadNewAndDestroyOldLevel(GameObject nextLevel)
    {
        if (levelToDestroy != null)
            Destroy(levelToDestroy);
        levelToDestroy = currentLevel;
        currentLevel = Instantiate(nextLevel, new Vector3(currentLevel.transform.position.x + currentLevelWidth, 0, 0), Quaternion.identity);
        levelsCompleted++;
    }

    void SetLevelDifficulty()
    {
        if (levelsCompleted == IncreaseDifficultyAfterLevels || levelsCompleted == IncreaseDifficultyAfterLevels * 2)
            currentLevelDifficulty++;
    }
}
