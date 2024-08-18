using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Rigidbody rb;

    private InputGame input;
    public Vector2 MovementDirection => input.Player.Movement.ReadValue<Vector2>();
    Vector2 direction;
    public Transform player;
    public Transform Camera;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        input = new InputGame();
        input.Enable();

    }

    private void Update()
    {
        RotateCamera();
        direction = MovementDirection;
    }

    void FixedUpdate()
    {
        Vector3 cameraForward = Camera.forward;
        Vector3 cameraRight = Camera.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 moveDirection = cameraForward * direction.y + cameraRight * direction.x;
        Vector3 nextPosition = moveDirection * movementSpeed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + nextPosition);
    }

    void RotateCamera()
    {
        Vector3 cameraForward = Camera.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        if (cameraForward != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(cameraForward);
            player.rotation = Quaternion.Slerp(player.rotation, rotation, Time.deltaTime * 5);
        }
    }
}