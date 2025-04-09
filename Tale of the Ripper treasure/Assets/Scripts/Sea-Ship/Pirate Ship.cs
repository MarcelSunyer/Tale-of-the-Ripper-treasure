using Ditzelgames;
using UnityEngine;

public class PirateShip : MonoBehaviour
{
    public Transform motor;
    [SerializeField] private float steerPower = 150f; // Reducida potencia inicial
    public float power = 5f;
    public float maxSpeed = 10f;
    [SerializeField] private float rotationDrag = 0.2f; // Nueva variable para arrastre de rotación
    [Range(0, 1)][SerializeField] private float steeringSensitivity = 0.01f; // Control de sensibilidad

    protected Rigidbody rigidbody;
    protected Quaternion startRotation;
    protected ParticleSystem particleSystem;

    public void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularDrag = rotationDrag; // Aplicar arrastre angular
        startRotation = motor.localRotation;
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    public void FixedUpdate()
    {
        float steerInput = 0f;

        // Entrada suavizada
        if (Input.GetKey(KeyCode.A))
            steerInput = Mathf.Lerp(steerInput, -1f, steeringSensitivity);
        else if (Input.GetKey(KeyCode.D))
            steerInput = Mathf.Lerp(steerInput, 1f, steeringSensitivity);
        else
            steerInput = Mathf.Lerp(steerInput, 0f, steeringSensitivity * 2); // Retorno más rápido

        // Fuerza de rotación con suavizado y deltaTime
        float steeringForce = steerInput * steerPower * Time.fixedDeltaTime;
        rigidbody.AddTorque(transform.up * steeringForce, ForceMode.Force);

        // Movimiento hacia adelante/atrás (sin cambios)
        var forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);
        if (Input.GetKey(KeyCode.W))
            PhysicsHelper.ApplyForceToReachVelocity(rigidbody, forward * maxSpeed, power);
        if (Input.GetKey(KeyCode.S))
            PhysicsHelper.ApplyForceToReachVelocity(rigidbody, forward * -maxSpeed, power);

        // Animación del motor más suave
        float targetSteerAngle = Mathf.Clamp(steerInput * 15f, -15f, 15f); // Ángulo reducido
        motor.localRotation = Quaternion.Slerp(
            motor.localRotation,
            startRotation * Quaternion.Euler(0, targetSteerAngle, 0),
            Time.fixedDeltaTime * 5f
        );

        // Sistema de partículas
        if (particleSystem != null)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                if (!particleSystem.isPlaying) particleSystem.Play();
                var emission = particleSystem.emission;
                emission.rateOverTime = rigidbody.velocity.magnitude * 2f;
            }
            else
            {
                particleSystem.Stop();
            }
        }

        // Corrección de velocidad con suavizado
        float currentSpeed = rigidbody.velocity.magnitude;
        rigidbody.velocity = Vector3.Lerp(
            rigidbody.velocity,
            transform.forward * currentSpeed,
            Time.fixedDeltaTime * rotationDrag
        );
    }
}