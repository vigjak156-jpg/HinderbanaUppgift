using System.Numerics;
using UnityEngine;
using System.Collections;

public class PlayerFrontWheels : MonoBehaviour
{
    [SerializeField] private Player Player;
    [SerializeField] private float TurnDegree = 40f;

    private float TurnDegreePos;
    private float TurnDegreeNeg;

    private Rigidbody2D[] rb;
    private float BodyRotation;

    private void Awake()
    {
        rb = GetComponentsInChildren<Rigidbody2D>(true);


        TurnDegreePos = TurnDegree;
        TurnDegreeNeg = -TurnDegree;

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
        TurnDegreePos = TurnDegree;
        TurnDegreeNeg = -TurnDegree;
        BodyRotation = Mathf.Round(GetComponentInParent<Rigidbody2D>().rotation);

        float SteerAmount = Player.SteerSpeed * Player.SteerInput;
        if(Player.SteerInput != 0f)
        {
            foreach (Rigidbody2D Wheel in rb)
            {
                int rotation = (int)Mathf.Round(Wheel.rotation);

                Debug.Log("Wheel rotation: " + rotation);
                Debug.Log("Body rotation: " + BodyRotation);
                if (rotation <= TurnDegreePos & rotation >= TurnDegreeNeg)
                {
                    Debug.Log("Wheel movement");
                    if (rotation - BodyRotation + SteerAmount * Time.fixedDeltaTime >= TurnDegreePos - BodyRotation)
                    {
                        Debug.Log("Pos");
                        continue;
                    }
                    if (rotation - BodyRotation + SteerAmount * Time.fixedDeltaTime <= TurnDegreeNeg - BodyRotation)
                    {
                        Debug.Log("Neg");
                        continue;
                    }
                    Wheel.MoveRotation(rotation + SteerAmount * Time.fixedDeltaTime);
                }
            }
        }

    }
}
