using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used for player movement, animation triggering, 
/// sprite rotation and hand object rotation, which are linked to cursor position. 
/// </summary>
[RequireComponent(typeof(Player))]
public class PlayerMover : MonoBehaviour
{
    private bool canMove;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private Vector2 targetVelocity;
    [HideInInspector] public Vector2 handToMouseDirection;
    [HideInInspector] public float handToMouseRotation;

    public float movementSpeed;

    private Transform hand;
    private float handLength;

    void Start()
    {
        canMove = true;
        hand = GetComponent<Player>().hand;
        handLength = GetComponent<Player>().handLength;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (canMove)
        {
            targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            handToMouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            handToMouseRotation = Mathf.Atan2(handToMouseDirection.y, handToMouseDirection.x) * Mathf.Rad2Deg;

            hand.position = new Vector3(transform.position.x + handLength * handToMouseDirection.normalized.x,
                                        transform.position.y + handLength * handToMouseDirection.normalized.y - handLength, 0);

            float angle = Mathf.Atan2(handToMouseDirection.y, handToMouseDirection.x) * Mathf.Rad2Deg;
            Quaternion handRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            hand.rotation = handRotation;

            if (targetVelocity.magnitude > 0)
                animator.SetBool("IsWalking", true);
            else
                animator.SetBool("IsWalking", false);

            if (handToMouseRotation > 90f || handToMouseRotation < -90f)
            { hand.localScale = new Vector3(1, -1, 1); spriteRenderer.flipX = true; }
            else
            { hand.localScale = new Vector3(1, 1, 1); spriteRenderer.flipX = false; }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + targetVelocity * movementSpeed * Time.deltaTime);
    }
}
