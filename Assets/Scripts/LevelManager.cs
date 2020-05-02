using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float levelWidth = 30;
    public int levelsCompleted = 0;
    public int IncreaseDifficultyAfterLevels = 5;
    public int currentLevelDifficulty = 1;
    public GameObject currentLevel;
    public GameObject creature;
    public GameObject[] levelPrefab;

    GameObject levelToDestroy;

    public void pickLevel()
    {
        GameObject nextLevel = levelPrefab[Random.Range(0, levelPrefab.Length)];
        loadNewAndDestroyOldLevel(nextLevel);
        CheckLevelDifficulty();
    }

    void loadNewAndDestroyOldLevel(GameObject nextLevel)
    {
        if (levelToDestroy != null)
            Destroy(levelToDestroy);
        levelToDestroy = currentLevel;
        currentLevel = Instantiate(nextLevel, new Vector3(currentLevel.transform.position.x + levelWidth, 0, 0), Quaternion.identity);
    }

    void CheckLevelDifficulty()
    {
        if (levelsCompleted == IncreaseDifficultyAfterLevels || levelsCompleted == IncreaseDifficultyAfterLevels * 2 || levelsCompleted == IncreaseDifficultyAfterLevels * 3)
            currentLevelDifficulty++;
    }
}
