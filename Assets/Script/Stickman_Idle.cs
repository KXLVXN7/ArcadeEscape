using System.Runtime.CompilerServices;
using UnityEngine;

public class Stickman_Idle : MonoBehaviour
{
    public float gravity;
    public Vector2 velocity; // Properti untuk kecepatan stickman
/*    public float jumpVelocity = 20;
    public float groundHeight = 10;
    public bool isGrounded = false;

    public bool isHoldingJump = false;
    public float maxHoldJumpTime = 0.4f;
    public float holdJumpTimer = 0.0f;

    public float jumpGroundThreshold = 1;


    void Update()
    {
        Vector2 pos = transform.position;*/
/*        float groundDistance = Mathf.Abs(pos.y - groundHeight);


        if (isGrounded || groundDistance <= jumpGroundThreshold)
        {
            {
                if (Input.GetButtonDown("Jump"))
                {
                    isGrounded = false;
                    velocity.y = jumpVelocity;
                    isHoldingJump= true;
                }
            }
            if(Input.GetButtonUp("Jump"))
            {
                isHoldingJump = false;

            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;  
        if(!isGrounded)
        {
            if (isHoldingJump)
            {
                holdJumpTimer += Time.fixedDeltaTime;
                if (holdJumpTimer >= maxHoldJumpTime)
                {
                    isHoldingJump= false;
                }
            }
            pos.y += velocity.y * Time.fixedDeltaTime;
            if(!isHoldingJump){
                velocity.y += gravity * Time.fixedDeltaTime;
            }
            velocity.y += gravity * Time.fixedDeltaTime;
            
            if(pos.y <= groundHeight)
            {
                pos.y = groundHeight;
                isGrounded = true;
                holdJumpTimer = 0f;
            }
        }
        transform.position = pos;
    }*/
}
