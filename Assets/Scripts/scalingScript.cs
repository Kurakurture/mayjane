using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scalingScript : MonoBehaviour
{
    public bool bigger = true;

    private GameObject[] charactersForScale;
    private Vector3 characterScale;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            //ScaleCharacters();

            gameObject.SetActive(false);
        }
    }

    void ScaleCharacters()
    {
        charactersForScale = GameObject.FindGameObjectsWithTag("player");

        print(charactersForScale);

        foreach (GameObject characterForScale in charactersForScale)
        {
            characterScale = characterForScale.transform.localScale;
            if (bigger)
            {
                characterScale = new Vector3(characterScale.x * 1.5f, characterScale.y * 1.5f, characterScale.z * 1.5f);
                print(characterScale);
            }
            else
            {
                characterScale = new Vector3(characterScale.x * 0.7f, characterScale.y * 0.7f, characterScale.z * 0.7f);
            }
        }
    }
}
