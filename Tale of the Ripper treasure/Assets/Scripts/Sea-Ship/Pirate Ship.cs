using Ditzelgames;
using StarterAssets;
using UnityEngine;

public class PirateShip : MonoBehaviour
{
    [Header("Ship Controls")]
    public Transform motor;
    [SerializeField] private float steerPower = 70f;
    [SerializeField] private float velocityStabilization = 0.5f;
    [SerializeField] private float maxAngularSpeed = 1.2f;
    [SerializeField] private float positionDamping = 3f;
    public float power = 5f;
    public float maxSpeed = 10f;
    [SerializeField] private float rotationDrag = 1.2f;
    [Range(0, 1)][SerializeField] private float steeringSensitivity = 0.01f;

    [Header("References")]

    public ThirdPersonController capitan;
    public Transform playerSeatPosition;

    protected Rigidbody rigidbody;
    protected Quaternion startRotation;
    protected ParticleSystem particleSystem;
    private float originalMoveSpeed;
    private bool canMove = false;
    private Vector3 originalPlayerPosition;

    public CameraTransition cameraTransition;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularDrag = rotationDrag;
        startRotation = motor.localRotation;
        particleSystem = GetComponentInChildren<ParticleSystem>();

        if (capitan != null)
        {
            originalMoveSpeed = capitan.MoveSpeed;
            originalPlayerPosition = capitan.transform.position;
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            HandleShipControl();
            HandleShipExit();
            StabilizePlayerPosition();
        }
    }

    private void HandleShipControl()
    {
        float steerInput = CalculateSteerInput();
        ApplyShipRotation(steerInput);
        ApplyShipMovement();
        UpdateShipVisuals(steerInput);
        StabilizeShipMovement();
    }

    private float CalculateSteerInput()
    {
        float steerInput = 0f;

        if (Input.GetKey(KeyCode.A))
            steerInput = Mathf.Lerp(steerInput, -1f, steeringSensitivity);
        else if (Input.GetKey(KeyCode.D))
            steerInput = Mathf.Lerp(steerInput, 1f, steeringSensitivity);
        else
            steerInput = Mathf.Lerp(steerInput, 0f, steeringSensitivity * 2);

        return Mathf.Clamp(steerInput, -1f, 1f);
    }

    private void ApplyShipRotation(float steerInput)
    {
        float steeringForce = steerInput * steerPower * Time.fixedDeltaTime;
        rigidbody.AddTorque(transform.up * steeringForce, ForceMode.Force);
        rigidbody.angularVelocity = Vector3.ClampMagnitude(rigidbody.angularVelocity, maxAngularSpeed);
    }

    private void ApplyShipMovement()
    {
        var forward = Vector3.Scale(new Vector3(1, 0, 1), transform.forward);

        if (Input.GetKey(KeyCode.W))
            PhysicsHelper.ApplyForceToReachVelocity(rigidbody, forward * maxSpeed, power);

        if (Input.GetKey(KeyCode.S))
            PhysicsHelper.ApplyForceToReachVelocity(rigidbody, forward * -maxSpeed, power);
    }

    private void UpdateShipVisuals(float steerInput)
    {
        float targetSteerAngle = Mathf.Clamp(steerInput * 15f, -15f, 15f);
        motor.localRotation = Quaternion.Slerp(
            motor.localRotation,
            startRotation * Quaternion.Euler(0, targetSteerAngle, 0),
            Time.fixedDeltaTime * 5f
        );

        if (particleSystem != null)
        {
            bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);
            UpdateParticles(isMoving);
        }
    }

    private void UpdateParticles(bool isMoving)
    {
        if (isMoving)
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

    private void StabilizeShipMovement()
    {
        rigidbody.velocity = Vector3.Lerp(
            rigidbody.velocity,
            transform.forward * rigidbody.velocity.magnitude,
            Time.fixedDeltaTime * velocityStabilization
        );
    }

    private void StabilizePlayerPosition()
    {
        if (capitan != null)
        {
            capitan.transform.position = Vector3.Lerp(
                capitan.transform.position,
                playerSeatPosition.position,
                Time.fixedDeltaTime * positionDamping
            );
        }
    }

    private void HandleShipExit()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            canMove = false;
            rigidbody.velocity = Vector3.zero;

            // Restore player control
            capitan.MoveSpeed = originalMoveSpeed;
            capitan.GetComponent<CharacterController>().enabled = true;
            capitan.transform.SetParent(null);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateShipControl();
        }
    }

    private void ActivateShipControl()
    {
        cameraTransition.TransitionCameras();
        // Reset physics
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;

        // Configure player
        capitan.MoveSpeed = 0;
        capitan.GetComponent<CharacterController>().enabled = false;
        capitan.transform.SetParent(transform);
        originalPlayerPosition = capitan.transform.localPosition;

        // Enable ship control
        //stayCapitan.SetActive(true);
        canMove = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !canMove)
        {
            

        }
    }
}