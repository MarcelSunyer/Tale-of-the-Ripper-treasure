using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionChangeScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Floor Colliders") 
        {
            Debug.Log("Josemaria");
            SceneManager.LoadScene("OnTheIsland");
        }
    }
   
}
