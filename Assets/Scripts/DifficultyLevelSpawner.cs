using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyLevelSpawner : MonoBehaviour
{
    public float ChanceToGetHigherDiff = 0.2f;
    public GameObject[] creatureSpawnerDiff1;
    public GameObject[] creatureSpawnerDiff2;
    public GameObject[] creatureSpawnerDiff3;
    public GameObject[] objectsForDiff1;
    public GameObject[] objectsForDiff2;
    public GameObject[] objectsForDiff3;
    public GameObject[] objectsSpawnerDiff1;
    public GameObject[] objectsSpawnerDiff2;
    public GameObject[] objectsSpawnerDiff3;

    LevelManager lm;

    void Awake()
    {
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    void Start()
    {
        SetDifficulty(lm.currentLevelDifficulty);
    }

    void SetDifficulty(int difficultyLevel)
    {
        int currentDiff;
        float rnd = Random.Range(0, 1);

        if (difficultyLevel < 3)
        {
            if (rnd > 1 - ChanceToGetHigherDiff)
                currentDiff = difficultyLevel + 1;
            else
                currentDiff = difficultyLevel;
        }
        else
        {
            if (rnd > 1 - ChanceToGetHigherDiff)
                currentDiff = difficultyLevel -1;
            else
                currentDiff = difficultyLevel;
        }
        spawnCreatures(currentDiff);
        spawnObjects(currentDiff);
    }

    void spawnCreatures(int diff)
    {
        switch (diff)
        {
            case 1:
                foreach (GameObject spawner in creatureSpawnerDiff1)
                    Instantiate(lm.creature, spawner.transform.position, Quaternion.identity);
                break;
            case 2:
                foreach (GameObject spawner in creatureSpawnerDiff2)
                    Instantiate(lm.creature, spawner.transform.position, Quaternion.identity);
                break;
            case 3:
                foreach (GameObject spawner in creatureSpawnerDiff3)
                    Instantiate(lm.creature, spawner.transform.position, Quaternion.identity);
                break;
        }
    }

    void spawnObjects(int diff)
    {
        switch (diff)
        {
            case 1:
                foreach (GameObject spawner in objectsSpawnerDiff1)
                    Instantiate(objectsForDiff1[Random.Range(0, objectsForDiff1.Length)], spawner.transform.position, Quaternion.identity);
                break;
            case 2:
                foreach (GameObject spawner in objectsSpawnerDiff2)
                    Instantiate(objectsForDiff2[Random.Range(0, objectsForDiff2.Length)], spawner.transform.position, Quaternion.identity);
                break;
            case 3:
                foreach (GameObject spawner in objectsSpawnerDiff3)
                    Instantiate(objectsForDiff3[Random.Range(0, objectsForDiff3.Length)], spawner.transform.position, Quaternion.identity);
                break;
        }
    }
}
