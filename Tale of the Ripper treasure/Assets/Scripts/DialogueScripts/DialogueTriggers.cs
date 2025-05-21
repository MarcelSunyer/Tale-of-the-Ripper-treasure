using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;

public class DialogueTriggers : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSONLow;
    [SerializeField] private TextAsset inkJSONNeutral;
    [SerializeField] private TextAsset inkJSONHigh;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        
    }
    private void Update()
    {
        if (playerInRange && !DialogManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                int loyaltyT = ((IntValue)DialogManager.GetInstance().GetVariableState("Tomasso_Loyalty")).value;

                if(loyaltyT < 30)
                {
                    DialogManager.GetInstance().EnterDialogueMode(inkJSONLow);
                }
                else if (loyaltyT >= 30 && loyaltyT< 75)
                {
                    DialogManager.GetInstance().EnterDialogueMode(inkJSONNeutral);
                }
                else
                {
                    DialogManager.GetInstance().EnterDialogueMode(inkJSONHigh);
                }
                
                
            }
        }
        else
        {
            visualCue.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
