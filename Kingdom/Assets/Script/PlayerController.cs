using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Take and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;

    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    public SwordAttack swordAttack;

    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movementInput;

    public SpriteRenderer spriteRenderer;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public bool canMove = true;

    // Start is called before the first frame update
    private void Awake()
    {
       
    }
    void Start()
    {

    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            // if movement input is not 0 try to move
            if (movementInput != Vector2.zero)
            {
                bool success = TryMove(movementInput);
                if (!success)
                {
                    success = TryMove(new Vector2(movementInput.x, 0));
                }
                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
               
                animator.SetFloat("Horizontal", movementInput.x);
                animator.SetFloat("Vertical", movementInput.y);
                animator.SetFloat("Speed", movementInput.sqrMagnitude);
            }
            else
            {
                animator.SetFloat("Speed", movementInput.sqrMagnitude);
            }
            //set direction of sprite and attack to movement direction
            if (movementInput.x < 0)
            {
                spriteRenderer.flipX = true;
                swordAttack.attackDirection = SwordAttack.AttackDirection.Right;
            }
            else if (movementInput.x > 0)
            {
                spriteRenderer.flipX = false;
                swordAttack.attackDirection = SwordAttack.AttackDirection.Left;

            }
            else if (movementInput.y > 0)
            {
                spriteRenderer.flipX = false;
                swordAttack.attackDirection = SwordAttack.AttackDirection.Up;

            }
            else if (movementInput.y < 0)
            {
                spriteRenderer.flipX = false;
                swordAttack.attackDirection = SwordAttack.AttackDirection.Down;

            }
        }
            
    }

    // this has become Try move so that i can still slide on either x or Y if i'm pressing on both of them while colliding only in one direction. It makes movement feel better
    private bool TryMove(Vector2 direction)
    {
        if(direction != Vector2.zero)
                
        {
            int count = rb.Cast(
                           direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
                           movementFilter, // The setting that determine where a collision can occur on such 
                           castCollisions,
                           moveSpeed * Time.fixedDeltaTime + collisionOffset);
            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

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
