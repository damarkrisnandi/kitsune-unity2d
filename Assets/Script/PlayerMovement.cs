using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 playerVelocity;
    public Transform player;
    private bool groundedPlayer;
    [SerializeField] private float constanstSpeed = 1f;
    private float playerSpeed = 0f;
    [SerializeField] private float jumpHeight = 10f;
    private float gravityValue = -9.81f;
    private bool m_FacingRight = true;
    private bool isGrounded = true;
    private bool isCrouching = false;
    public Animator anim;

    private void Start()
    {
    }

    private void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.name == "Ground") {
            isGrounded = true;
            Animate_Jump();
        }
    }

    void FixedUpdate()
    {
        // default condition
        Animate_Run(0f);
        Animate_Jump();
        Animate_Crouch();


        MoveRight();

        MoveLeft();

        Jump();

        Crouch();

    }

    private void Flip(){
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = player.localScale;
		theScale.x *= -1;
		player.localScale = theScale;
	}

    private void MoveRight() {
        if (Input.GetKey(KeyCode.D))
        {
            playerSpeed = constanstSpeed;
            if (!m_FacingRight) Flip();
            Animate_Run(playerSpeed);
            player.position += new Vector3(playerSpeed, 0, 0);
        }

        
    }

    private void MoveLeft() {
        if (Input.GetKey(KeyCode.A))
        {
            playerSpeed = constanstSpeed;
            if (m_FacingRight) Flip();
            Animate_Run(playerSpeed);
            player.position += new Vector3(-playerSpeed, 0, 0);
        }
        
    }

    private void Jump() {
       if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // player.position += new Vector3(0, Mathf.Sqrt(jumpHeight * -3.0f * gravityValue), 0);
            GetComponent<Rigidbody2D>().AddForce(transform.up * Mathf.Sqrt(jumpHeight * -30.0f * gravityValue), ForceMode2D.Impulse);
            isGrounded = !isGrounded;
            Animate_Jump();
        } 
    }

    private void Crouch() {
        if (Input.GetKeyUp(KeyCode.S))
        {
            isCrouching = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            isCrouching = true;
        }
        Animate_Crouch();
    }

    private void Animate_Run(float speed) {
        anim.SetFloat("Speed", speed);
    }

    private void Animate_Jump() {
        anim.SetBool("IsGrounded", isGrounded);
    }

    private void Animate_Crouch() {
        anim.SetBool("IsCrouching", isCrouching);
    }
    
}
