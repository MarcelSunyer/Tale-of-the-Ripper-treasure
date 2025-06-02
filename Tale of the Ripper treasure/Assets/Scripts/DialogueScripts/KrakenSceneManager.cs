using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenSceneManager : MonoBehaviour
{
    private int dialogsPlayedK;
    private bool decision;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset Desicion;

    [SerializeField] private GameObject firstMiss;
    [SerializeField] private GameObject secondMiss;

    // Start is called before the first frame update
    void Start()
    {
        decision = false;
    }

    // Update is called once per frame
    void Update()
    {
        dialogsPlayedK = DialogManager.GetInstance().dialogsPlayed;
        if ( dialogsPlayedK == 3 && decision== false && !DialogManager.GetInstance().dialogueIsPlaying)
        {
            firstMiss.SetActive(false);
            decision= true;
            DialogManager.GetInstance().EnterDialogueMode(Desicion);
            secondMiss.SetActive(true);
        }
    }
}
