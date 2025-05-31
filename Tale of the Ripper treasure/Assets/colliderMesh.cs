using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class colliderMesh : MonoBehaviour
{
    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshCollider meshCollider = GetComponent<MeshCollider>();

        if (meshFilter == null || meshFilter.sharedMesh == null)
        {
            Debug.LogError("Este objeto no tiene una Mesh válida.");
            return;
        }

        // Clonamos la malla para asegurarnos de que no hay referencias compartidas
        Mesh meshCopy = Instantiate(meshFilter.sharedMesh);
        meshCopy.RecalculateNormals(); // Opcional: asegura que las normales estén bien
        meshCopy.RecalculateBounds();  // Muy importante para colliders

        // Asignamos esa malla al collider
        meshCollider.sharedMesh = null;           // Forzamos el refresh
        meshCollider.sharedMesh = meshCopy;
        meshCollider.convex = false;              // Ajusta según tu necesidad

        Debug.Log("MeshCollider actualizado con la malla del MeshFilter.");
    }
}
