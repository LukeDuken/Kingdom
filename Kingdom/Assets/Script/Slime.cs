using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float damage = 1.0f;

    public float knockbackForce = 500f;

    public float moveSpeed = 1.0f;

    public EnemyAggro aggro;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        if (aggro.detectObjs.Count > 0)
        {
            //calculate the direction to target object
            Vector2 direction = (aggro.detectObjs[0].transform.position - transform.position).normalized;
            //move towards the detected object
            rb.AddForce(direction * moveSpeed * Time.deltaTime);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D collider = col.collider;
        IDamageable damageable= collider.GetComponent<IDamageable>();

        if (damageable != null)
        {
            //Offset for collision direction changes the direction where the force comes from (close to the player)
            Vector2 direction = (collider.transform.position - transform.position).normalized;

            //knockback is in direction of swordCollider towards collider
            Vector2 knockback = direction * knockbackForce;

            // After making sure the collider has a script that implements IDamagable, we can run the OnHit implementation and pass over our Vector 2 force
            damageable.OnHit(damage, knockback);
        }
    }
}
