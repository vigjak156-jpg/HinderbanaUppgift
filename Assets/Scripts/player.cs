using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private CameraScript MainCamera;
    [SerializeField] public float MoveSpeed = 15f;
    [SerializeField] public float SteerSpeed = 250f;

    public float SteerInput;
    public float MoveInput;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MoveInput = 0f;
        if (Keyboard.current.wKey.isPressed)
        {
            MoveInput = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            MoveInput = -1f;
        }

        SteerInput = 0f;
        if (Keyboard.current.aKey.isPressed)
        {
            SteerInput = 1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            SteerInput = -1f;
        }
    }

    private void FixedUpdate()
    {


        MainCamera.UpdatePosition(rb.transform.position);
    }
}
