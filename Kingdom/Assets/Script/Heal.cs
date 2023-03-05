using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    Rigidbody2D rb;

    public Animator animator;
    public float heal = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D collider = col.collider;
        IDamageable damageable = collider.GetComponent<IDamageable>();

        if (damageable != null)
        {
            // After making sure the collider has a script that implements IDamagable, we can run the OnHeal implementation and pass over our Vector 2 force
            damageable.OnHeal(heal);
            print("heal");
            animator.SetBool("collected", true);

        }
    }
    public void OnObjectDestroy()
    {
        Destroy(gameObject);
    }
}
