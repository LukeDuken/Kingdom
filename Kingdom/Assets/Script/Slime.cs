using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    
    public Animator animator;
    public float _health = 3f;
    
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
                animator.SetBool("IsAlive", false);
            }
            
        }
        get { return _health; }
    }

    private void OnHit(float damage)
    {
        Debug.Log("slime hit for" + damage);
        Health -= damage;
    }
}
