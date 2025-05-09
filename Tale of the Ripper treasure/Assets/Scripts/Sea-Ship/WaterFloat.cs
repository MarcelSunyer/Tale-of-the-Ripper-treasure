using Ditzelgames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WaterFloat : MonoBehaviour
{
    public float airDrag = 1;
    public float waterDrag = 10;
    public bool affectDirection = true;
    public bool attachToSurface = false;
    public Transform[] floatPoints;

    //used components
    protected Rigidbody rigidbody;
    protected Waves waves;

    //water line
    protected float waterLine;
    protected Vector3[] waterLinePoints;

    //help Vectors
    protected Vector3 smoothVectorRotation;
    protected Vector3 targetUp;
    protected Vector3 centerOffset;

    public Vector3 center
    {
        get
        {
            return transform.position + centerOffset;
        }
    }

    void Awake()
    {
        waves = FindAnyObjectByType<Waves>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;

        waterLinePoints = new Vector3[floatPoints.Length];
        for (int i = 0; i < floatPoints.Length; i++)
        {
            waterLinePoints[i] = floatPoints[i].position;
        }

        centerOffset = PhysicsHelper.GetCenter(waterLinePoints) - transform.position;
    }

    void FixedUpdate()
    {
        //default water surface
        var newWaterLine = 0f;
        var pointUnderWater = false;

        //set WaterLinePoints and WaterLine
        for (int i = 0; i < floatPoints.Length; i++)
        {
            //height
            waterLinePoints[i] = floatPoints[i].position;
            waterLinePoints[i].y = waves.GetHeight(floatPoints[i].position);
            newWaterLine += waterLinePoints[i].y / floatPoints.Length;
            if (waterLinePoints[i].y > floatPoints[i].position.y)
                pointUnderWater = true;
        }

        var waterLineDelta = newWaterLine - waterLine;
        waterLine = newWaterLine;

        //compute up vector
        targetUp = PhysicsHelper.GetNormal(waterLinePoints);

        //gravity
        var gravity = Physics.gravity;
        rigidbody.drag = airDrag;
        if (waterLine > center.y)
        {
            rigidbody.drag = waterDrag;
            //under water
            if (attachToSurface)
            {
                //attach to water surface
                rigidbody.position = new Vector3(rigidbody.position.x, waterLine - centerOffset.y, rigidbody.position.z);
            }
            else
            {
                //go up
                gravity = affectDirection ? targetUp * -Physics.gravity.y : -Physics.gravity;
                transform.Translate(Vector3.up * waterLineDelta * 0.9f);
            }
        }
        if (waterLine > center.y)
        {
            // Modificar esta l�nea para reducir la fuerza de gravedad
            rigidbody.AddForce(gravity * Mathf.Clamp(Mathf.Abs(waterLine - center.y), 0, 0.5f));
        }

        //rotation
        if (pointUnderWater)
        {
            //attach to water surface
            targetUp = Vector3.SmoothDamp(transform.up, targetUp, ref smoothVectorRotation, 0.2f);
            rigidbody.rotation = Quaternion.FromToRotation(transform.up, targetUp) * rigidbody.rotation;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if(floatPoints == null)
        {
            return;
        }

        for (int i = 0; i < floatPoints.Length; i++)
        {
            if (floatPoints[i] == null)
            {
                return;
            }

            if(waves != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawCube(waterLinePoints[i], Vector3.one * 0.3f);
            }

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(floatPoints[i].position, 0.1f);
        }

        if(Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(new Vector3(center.x,waterLine,center.z), Vector3.one * 1f);
        }
    }
}
