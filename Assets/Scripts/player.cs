using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{

    [SerializeField] public float steerSpeed = 15f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] private CameraScript MainCamera;


    public float steerInput;
    public float moveInput;

    private Rigidbody2D rb;




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        moveInput = 0f;
        if (Keyboard.current.wKey.isPressed)
        {
            moveInput = 1f;
        } else if(Keyboard.current.sKey.isPressed)
        {
            moveInput = -1f;
        }

        steerInput = 0f;
        if (Keyboard.current.aKey.isPressed)
        {
            steerInput = 1f;
        } else if (Keyboard.current.dKey.isPressed)
        {
            steerInput = -1f;
        }
    }

    private void FixedUpdate()
    {
        float steerAmount = steerSpeed * steerInput;

        Vector3 moveDircetion = transform.up;
        float accelerationForce = moveSpeed * moveInput;
        rb.AddForce(moveDircetion * accelerationForce);

        rb.MoveRotation(rb.rotation + steerAmount);

        MainCamera.UpdatePosition(rb.transform.position);
    }

    public void boostSpeed(float BoostAmount)
    {
        moveSpeed += BoostAmount;
    }
}
