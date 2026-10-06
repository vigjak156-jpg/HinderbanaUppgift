using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayer : MonoBehaviour
{
    [SerializeField] private CameraScript MainCamera;
    [SerializeField] float moveSpeed = 15f;

    float steerInput;
    float moveInput;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveInput = 0f;
        if (Keyboard.current.wKey.isPressed)
        {
            moveInput = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            moveInput = -1f;
        }

        steerInput = 0f;
        if (Keyboard.current.aKey.isPressed)
        {
            steerInput = 1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steerInput = -1f;
        }
    }

    private void FixedUpdate()
    {


        MainCamera.UpdatePosition(rb.transform.position);
    }
}
