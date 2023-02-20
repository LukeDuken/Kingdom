using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float damage = 1.0f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable= collision.collider.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.OnHit(damage);
        }
    }
}
