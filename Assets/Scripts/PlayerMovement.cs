using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f;
    //serializeField to allow changes to variables in Unity editor
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum movementState { idle, skipping, jumping, falling }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Using float for horizontal movement to support controller inputs
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump")) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState() {
        movementState state;

        if (dirX > 0f) {
            state = movementState.skipping;
            sprite.flipX = false;
        }
        else if (dirX < 0f) {
            state = movementState.skipping;
            sprite.flipX = true;
        }
        else {
            state = movementState.idle;
        }

        if (rb.velocity.y > .1f) {
            state = movementState.jumping;
        }
        else if (rb.velocity.y < -.1f) {
            state = movementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }
}
