using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrakenCollisionDetector : MonoBehaviour
{
    [SerializeField] private TextAsset dialogAfterColliion;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ship")
        {
            Debug.Log("Barco Choca kraken");
            PirateShip script = other.GetComponent<PirateShip>();
            script.KrakenShipExit();

            Transform kraken = other.transform.Find("Kraken");
            kraken.gameObject.SetActive(true);
            DialogManager.GetInstance().EnterDialogueMode(dialogAfterColliion);
        }
    }
}
