using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerMovement_Photon : MonoBehaviourPun
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    private bool timerRunning = false;
    private float timeRemaining = 3f;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    private int carrots = 0;
    //serializeField to allow changes to variables in Unity editor
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;


    public static GameObject LocalPlayerInstance;
    //public CameraController _cameraController;

    private enum movementState { idle, skipping, jumping, falling }


    // Start is called before the first frame update
    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    private void Update()
    {
        //Photon pun
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }

        //Using float for horizontal movement to support controller inputs
        dirX = Input.GetAxis("Horizontal");
        if (carrots > 0) {
            rb.velocity = new Vector2(dirX * (moveSpeed + (2f * carrots)), rb.velocity.y);
            RunTimer();
        }
        else {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            FindObjectOfType<AudioManager>().Play("Jump");
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        movementState state;

        if (dirX > 0f)
        {
            state = movementState.skipping;
            //sprite.flipX = false;
            SwitchFlipX(false);
        }
        else if (dirX < 0f)
        {
            state = movementState.skipping;
            //sprite.flipX = true;
            SwitchFlipX(true);
        }
        else
        {
            state = movementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = movementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = movementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    public void SwitchFlipX(bool flipStatus)
    {

        base.photonView.RPC("RPC_ChangeFlipState", RpcTarget.All, flipStatus);

    }

    private void RunTimer() {
        if (timerRunning) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
            }
            else {
                timeRemaining = 0;
                carrots = 0;
                FindObjectOfType<AudioManager>().Play("Power Down");
                timerRunning = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Carrot")) {
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("Power Up");
            carrots++;
            timerRunning = true;
            timeRemaining = 3f;
        }
        //Need to include this in order to allow the player to move with the platform
        /*
        if (collision.gameObject.CompareTag("Moving Platform")) {
            collision.GetComponent<Collider>().transform.SetParent(transform);
        }
        */
    }
/*
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Moving Platform")) {
            collision.GetComponent<Collider>().transform.SetParent(null);
        }
    }
*/
    [PunRPC]
    private void RPC_ChangeFlipState(bool flipStatus)
    {
        sprite.flipX = flipStatus;
    }
}
