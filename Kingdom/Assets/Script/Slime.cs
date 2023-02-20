using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IDamagable
{
    
    public Animator animator;
    Rigidbody2D rb;
    public float _health = 3f;
    public bool _targetable = true;
    Collider2D physicsCollider;

    public void Start()
    {
        animator.SetBool("IsAlive", true);
        rb = GetComponent<Rigidbody2D>();
        physicsCollider= rb.GetComponent<Collider2D>();
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
    { get 
        {
            return _targetable; 
        }
        set 
        { 
            _targetable = value;
            rb.simulated = value;
            physicsCollider.enabled= value;


        } 
    }
    public void OnHit(float damage)
    {
        Health -= damage;
    }
    public void OnHit(float damage, Vector2 knockback)
    {
        Health -= damage;
        //apply force to the slime
        rb.AddForce(knockback);
    }

    public void OnObjectDestroy()
    {
        Destroy(gameObject);
    }
}
