using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLookAt : MonoBehaviour
{
    public GameObject targetPointIsland;
    public GameObject targetPointKraken;

    private int fightORFly;

    void Update()
    {
        fightORFly = ((IntValue)DialogManager.GetInstance().GetVariableState("FightDecision")).value;
        if(fightORFly == 0 )
        {
            // Calcula la dirección desde la flecha hacia el punto objetivo
            Vector3 direction = targetPointIsland.transform.position - transform.position;

            // Si la dirección no es cero, rota la flecha hacia ese punto
            if (-direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation( new Vector3(-direction.x, direction.y, direction.z));
                transform.rotation = lookRotation;
            }
        }
        else
        {
            // Calcula la dirección desde la flecha hacia el punto objetivo
            Vector3 direction = targetPointKraken.transform.position - transform.position;

            // Si la dirección no es cero, rota la flecha hacia ese punto
            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(-direction.x, direction.y, direction.z));
                transform.rotation = lookRotation;
            }
        }
        
        

        
        
    }
}
