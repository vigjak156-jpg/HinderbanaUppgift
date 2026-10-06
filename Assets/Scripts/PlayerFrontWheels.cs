using UnityEngine;

public class PlayerFrontWheels : MonoBehaviour
{
    [SerializeField] private player Player;


    private Rigidbody2D[] rb;

    private void Awake()
    {
        rb = GetComponentsInChildren<Rigidbody2D>(true);
        
        foreach (Rigidbody2D wheel in rb)
        {
            Debug.Log(wheel);
        }
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float steerAmount = Player.steerSpeed * Player.steerInput;
        if(Player.steerInput != 0f)
        {
            foreach (Rigidbody2D wheel in rb)
            {
                Debug.Log("Wheel rotated");
                wheel.MoveRotation(wheel.rotation + steerAmount);
            }
        }

    }
}
