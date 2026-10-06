using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] float CameraMoveSpeed = 15f;
    
    public void UpdatePosition(Vector3 Position)
    {
        Rigidbody2D rb;

        Vector3 CameraPosition = transform.position;

        Vector3 moveDirection = Position - CameraPosition;

        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(moveDirection * CameraMoveSpeed);
    }
}
