using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Take and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;

    public float maxSpeed = 5f;

    // Each frame of physics, what percentage of the speed should be shaved off the velocity out of 1 (100%)
    public float idleFriction = 0.9f;

    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    public SwordAttack swordAttack;

    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movementInput = Vector2.zero;

    public SpriteRenderer spriteRenderer;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public bool canMove = true;

    // Start is called before the first frame update
    private void Awake()
    {
        //swordAttack.attackDirection = SwordAttack.AttackDirection.Down;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }
    private void FixedUpdate()
    {
       // if movement input is not 0 try to move
            if (movementInput != Vector2.zero)
            {
            // setting velocity directly
            //rb.velocity = Vector2.ClampMagnitude(rb.velocity + (movementInput *moveSpeed* Time.deltaTime), maxSpeed);

            //add a force for move player around
            //rb.AddForce(movementInput* moveSpeed * Time.deltaTime);
            rb.AddForce(movementInput * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Force);

                UpdateAnimatorParameters();
                if(rb.velocity.magnitude > maxSpeed)
                {
                    //because maxSpeed is not a vector2 we need to set limitedSpeed and use the vector2 values for float
                    float limitedSpeed = Mathf.Lerp(rb.velocity.magnitude, maxSpeed, idleFriction);
                    rb.velocity = rb.velocity.normalized * limitedSpeed;
                }
            //set direction of sprite and attack to movement direction
                if (movementInput.x < 0)
                    {
                        
                        swordAttack.attackDirection = SwordAttack.AttackDirection.Right;
                    }
                    else if (movementInput.x > 0)
                    {
                     
                        swordAttack.attackDirection = SwordAttack.AttackDirection.Left;

                    }
                    else if (movementInput.y > 0)
                    {                   
                        swordAttack.attackDirection = SwordAttack.AttackDirection.Up;

                    }
                    else if (movementInput.y < 0)
                    {                    
                        swordAttack.attackDirection = SwordAttack.AttackDirection.Down;

                    }

                // still can move once when is death
                if (rb.velocity.x < 0)
                {
                    spriteRenderer.flipX = true;
                }
                else if (rb.velocity.x > 0) 
                {
                    spriteRenderer.flipX = false;
                }
            }
        else
        {
            //no movement so interpolate velocity towards 0
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);
            animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        }
        
    }
    void UpdateAnimatorParameters()
    {
        //play movement animation only when over a speed value 
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        //pick right movement animation according to axis magnitude
        animator.SetFloat("Horizontal", movementInput.x);
        animator.SetFloat("Vertical", movementInput.y);
    }
    void OnMove(InputValue movementValue) 
    {
        movementInput =movementValue.Get<Vector2>();
    }

    //Sword Attack
    void OnFire() 
    {
        animator.SetTrigger("Attack");   
    }
    public void EndAttack()
    {
        canMove = true;
        swordAttack.StopAttack();
    }
    public void Attack()
    {
        canMove = false;
        swordAttack.StartAttack();
        swordAttack.SwordSwing();

    }
}
