using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeK : MonoBehaviour
{

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSONNeutral;

    private bool talked;

    private void Awake()
    {
        talked = false;
    }
    private void Update()
    {

        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DialogManager.GetInstance().EnterDialogueMode(inkJSONNeutral);
        }
    }

}
