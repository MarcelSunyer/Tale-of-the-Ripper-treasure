using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLookAt : MonoBehaviour
{
    public GameObject targetPoint;

    void Update()
    {
        // Calcula la dirección desde la flecha hacia el punto objetivo
        Vector3 direction = targetPoint.transform.position - transform.position;

        // Si la dirección no es cero, rota la flecha hacia ese punto
        if (-direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation( new Vector3(-direction.x, direction.y, direction.z));
            transform.rotation = lookRotation;
        }
    }
}
