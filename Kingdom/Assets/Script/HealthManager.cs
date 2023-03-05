using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class HealthManager : MonoBehaviour, IDamageable
{
    public Animator animator;
    Rigidbody2D rb;
    public float _health = 3f;
    public float maxHealth = 5f;
    public bool _targetable = true;
    public bool disableSimulation = false;
    Collider2D physicsCollider;
    public float InvincibilityTime = 0.25f;
    public bool canTurnInvincible = false;
    private float invincibleTimeElapsed = 0f;

    public void Start()
    {
        animator.SetBool("IsAlive", true);
        rb = GetComponent<Rigidbody2D>();
        physicsCollider = rb.GetComponent<Collider2D>();
    }
    public float Health
    {
        set
        {
            if (value < _health)
            {
                animator.SetTrigger("Hit");
            }
            _health = value;
            if (_health <= 0)
            {
                Targetable = false;
                animator.SetBool("IsAlive", false);
            }

        }
        get { return _health; }
    }

    public bool Targetable
    {
        get
        {
            return _targetable;
        }
        set
        {
            _targetable = value;
            //For player or characters that we want to stop on death
            if (disableSimulation)
            {
                rb.simulated = false;
            }
            physicsCollider.enabled = value;


        }
    }

    public bool Invincible
    {
        get
        {
            return _invincible;

        }

        set 
        {
            _invincible = value;
            if (_invincible == true)
            {
                invincibleTimeElapsed = 0f;
            }
        }
    }
    public bool _invincible = false;

    public void OnHit(float damage, Vector2 knockback)
    {
        if (!Invincible)
        {
            Health -= damage;
            //apply force to the slime
            rb.AddForce(knockback, ForceMode2D.Impulse);
            if(canTurnInvincible)
            {
                //activate invincibility and timer
                Invincible = true;
            }
        }
    }
    public void OnHit(float damage)
    {
        if (!Invincible)
        {
            Health -= damage;
            if (canTurnInvincible)
            {
                //activate invincibility and timer
                Invincible = true;
            }
        }
    }

    public void OnHeal(float heal)
    {
        if (Health < maxHealth)
        {
            Health += heal;
        }       
    }

    public void OnObjectDestroy()
    {
        Destroy(gameObject);
    }

    public void FixedUpdate()
    {
        if(Invincible)
        {
            invincibleTimeElapsed += Time.deltaTime;
            if(invincibleTimeElapsed> InvincibilityTime ) 
            {
                Invincible= false;
            }
        }
    }

}
