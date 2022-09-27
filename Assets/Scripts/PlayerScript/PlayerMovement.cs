using System.Collections;
using System.Collections.Generic;
//using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    //serializeField to allow changes to variables in Unity editor
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;




    private enum movementState { idle, skipping, jumping, falling }

    /*
    private void Awake()
    {
        if (photonView.IsMine)
        {
            PlayerSetting.LocalPlayerInstance = this.gameObject;
        }
    }
    */

    // Start is called before the first frame update
    private void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        
        /*
        if (_cameraController != null)
        {
            if (photonView.IsMine)
            {
                Debug.Log("photonView.IsMine");
                _cameraController.OnStartFollowing(this.gameObject);
            }
        }
        else
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> CameraWork Component on playerPrefab.", this);
        }
        */
    }

    // Update is called once per frame
    private void Update()
    {
        //Photon pun

        //Using float for horizontal movement to support controller inputs
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded()) {
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

    private bool IsGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
