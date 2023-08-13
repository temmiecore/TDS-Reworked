using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public float offsetStrength = 0.1f;

    public Vector2 handToMouseDirection;
    public Vector2 offset;

    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        handToMouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - target.position;
    }

    void FixedUpdate()
    {
        offset = handToMouseDirection * offsetStrength;
        Vector2 desiredPosition = new Vector2(target.position.x, target.position.y) + offset;
        Vector2 smoothedPosition = Vector2.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, -10);
    }
}