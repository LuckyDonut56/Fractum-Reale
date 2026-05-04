using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float gravity = -9.81f;

    [Header("Mouse Look")]
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float maxLookAngle = 80f;
    [SerializeField] private float interactionDistance = 5f;

    [Header("Camera Bobbing")]
    [SerializeField] private  bool enableCameraBobbing = true;
    [SerializeField] private float bobbingAmount = 0.05f;
    [SerializeField] private float bobbingSpeed = 0.18f;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource stepsAudioSource;
    [SerializeField] private AudioClip[] stepSounds;
    [SerializeField] private float stepInterval = 0.5f;
    [SerializeField] private float runStepInterval = 0.25f;

    private Camera playerCamera;
    private CharacterController characterController;
    private AudioSource[] audsrcs;
    private AudioSource step;
    private AudioSource fall;
    private Vector3 velocity;
    private Vector3 cameraOriginalPosition;
    private bool isGrounded;
    private float xRotation = 0f;
    private float bobbingTimer = 0f;
    private float stepTimer = 0f;
    private bool wasMoving = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        audsrcs = GetComponents<AudioSource>();
        cameraOriginalPosition = playerCamera.transform.localPosition;
        step = audsrcs[0];
        fall = audsrcs[1];
        Time.timeScale = 1;
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        HandleMouseLook();
        HandleMovement();
        HandleJump();
        HandleCameraBobbing();
        HandleStepSounds();
        Interaction();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * GameSettings.Instance.mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * GameSettings.Instance.mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        bool playfall = false;
        if (!isGrounded) playfall = true;
        isGrounded = characterController.isGrounded;
        if (isGrounded && playfall) fall.Play();
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) && isGrounded ? runSpeed : walkSpeed;

        characterController.Move(moveDirection * currentSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        if (isGrounded && (horizontal != 0 || vertical != 0)) {
            if (!step.isPlaying)
                step.Play();
                step.loop = true;
        } else step.loop = false;
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    void HandleCameraBobbing()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);

        if (movement.magnitude > 0.1f && isGrounded)
        {
            bobbingTimer += Time.deltaTime * bobbingSpeed;
            float bobbing = Mathf.Sin(bobbingTimer) * bobbingAmount;

            Vector3 newPosition = cameraOriginalPosition;
            newPosition.y += bobbing;
            newPosition.x += bobbing;
            playerCamera.transform.localPosition = newPosition;
        }
        else
        {
            bobbingTimer = 0f;
            playerCamera.transform.localPosition = Vector3.Lerp(playerCamera.transform.localPosition, cameraOriginalPosition, Time.deltaTime * bobbingSpeed);
        }
    }

    void Interaction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Transform cameraTransform = Camera.main.transform;
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, interactionDistance))
            {
                foreach(var interactable in hit.collider.GetComponents<IInteractable>())
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
    }

    void HandleStepSounds()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool isMoving = (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f) && isGrounded;
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && isGrounded;

        float currentInterval = isRunning ? runStepInterval : stepInterval;
        if (isMoving && !wasMoving)
        {
            PlayStepSound();
            stepTimer = 0f;
        }
        else if (isMoving)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= currentInterval)
            {
                PlayStepSound();
                stepTimer = 0f;
            }
        }
        else
            stepTimer = 0f;
        wasMoving = isMoving;
    }


    void PlayStepSound()
    {
        int randomIndex = Random.Range(0, stepSounds.Length);
        AudioClip selectedClip = stepSounds[randomIndex];

        if (selectedClip != null && stepsAudioSource != null)
        {
            stepsAudioSource.clip = selectedClip;
            stepsAudioSource.time = 0f;
            stepsAudioSource.Play();
        }
    }
}