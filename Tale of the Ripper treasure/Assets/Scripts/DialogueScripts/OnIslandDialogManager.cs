using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnIslandDialogManager : MonoBehaviour
{
    private int dialogsPlayedK;

    // Update is called once per frame
    void Update()
    {

        dialogsPlayedK = DialogManager.GetInstance().dialogsPlayed;
        if (dialogsPlayedK >= 1  && !DialogManager.GetInstance().dialogueIsPlaying)
        {
            SceneManager.LoadScene("EndScene");

        }
    }
}
