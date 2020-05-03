using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyLevelSpawner : MonoBehaviour
{
    public float ChanceToGetLowerDiff = 0.3f;
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
        TryToSpareDifficulty(lm.currentLevelDifficulty);
    }

    void TryToSpareDifficulty(int diff)
    {
        float rnd = Random.Range(0.0f, 1.0f);
        if (diff > 2 && rnd > 1 - ChanceToGetLowerDiff / 2)
            diff = diff - 2;
        else if (diff > 1 && rnd > 1 - ChanceToGetLowerDiff)
            diff--;
        spawnCreatures(diff);
        spawnObjects(diff);
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
