using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndIsland : MonoBehaviour
{
    public bool mission_completed;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && mission_completed)
        {
            SceneManager.LoadScene("Isle1_Done");
        }
        if(other.gameObject.tag == "Player" && !mission_completed)
        {
            SceneManager.LoadScene("Waves");
        }
    }
}
