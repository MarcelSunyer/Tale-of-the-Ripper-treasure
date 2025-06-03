using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenSceneManager : MonoBehaviour
{
    private int dialogsPlayedK;
    private bool decision;

    private int fightORFly;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset Desicion;

    [SerializeField] private GameObject firstMiss;
    [SerializeField] private GameObject secondMiss;
    [SerializeField] private GameObject timon;
    [SerializeField] private GameObject timonBefore;

    // Start is called before the first frame update
    void Start()
    {
        decision = false;
        fightORFly = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        fightORFly = ((IntValue)DialogManager.GetInstance().GetVariableState("FightDecision")).value;

        dialogsPlayedK = DialogManager.GetInstance().dialogsPlayed;
        if ( dialogsPlayedK == 3 && decision== false && !DialogManager.GetInstance().dialogueIsPlaying)
        {
            firstMiss.SetActive(false);
            decision= true;
            DialogManager.GetInstance().EnterDialogueMode(Desicion);
            timon.SetActive(true);
            timonBefore.SetActive(false);

        }
        if(decision)
        {
            fightORFly = ((IntValue)DialogManager.GetInstance().GetVariableState("FightDecision")).value;
            if (fightORFly == 1)
            {
                secondMiss.SetActive(true);
            }
        }
    }
}
