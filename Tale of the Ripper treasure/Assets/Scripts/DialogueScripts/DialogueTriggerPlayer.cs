using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerPlayer : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;

    }
    private void Update()
    {
        if (playerInRange && !DialogManager.GetInstance().dialogueIsPlaying)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Debug.Log(inkJSON.text);
            }
        }
        else
        {

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            playerInRange = true;
        }
    }
}
