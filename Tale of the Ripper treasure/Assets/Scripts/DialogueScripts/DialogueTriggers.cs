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

    [Header("NPC Name")]
    [SerializeField] private string npcName;

    private bool playerInRange;
    private int loyaltyT;
    private int loyaltyMiss;
    private int loyaltyMr;

    private bool talked;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
        talked = false;

    }
    private void Update()
    {
        loyaltyT = ((IntValue)DialogManager.GetInstance().GetVariableState("Tomasso_Loyalty")).value;
        loyaltyMiss = ((IntValue)DialogManager.GetInstance().GetVariableState("MissDisfortune_Loyalty")).value;
        loyaltyMr = ((IntValue)DialogManager.GetInstance().GetVariableState("MrDisfortune_Loyalty")).value;
        int loyalty = 0;
        if (playerInRange)
        {
            switch (npcName)
            {
                case "Tomasso":
                    loyalty = loyaltyT;
                    DialogManager.GetInstance().loyaltyText.text = "Tomasso Loyalty =" + loyaltyT;
                    break;

                case "Miss":
                    loyalty = loyaltyMiss;
                    DialogManager.GetInstance().loyaltyText.text = "Miss Loyalty =" + loyaltyMiss;
                    break;

                case "Mr":
                    loyalty = loyaltyMr;
                    DialogManager.GetInstance().loyaltyText.text = "Mr Loyalty =" + loyaltyMr;
                    break;
            }
        }

        if (playerInRange && !DialogManager.GetInstance().dialogueIsPlaying && talked == false)
        {
            

            visualCue.SetActive(true);

            

            if (Input.GetKeyDown(KeyCode.E))
            {
                talked = true;
                DialogManager.GetInstance().dialogsPlayed += 1;

                if (loyalty < 30)
                {
                    DialogManager.GetInstance().EnterDialogueMode(inkJSONLow);
                }
                else if (loyalty >= 30 && loyalty < 75)
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
