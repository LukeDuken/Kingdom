using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    Rigidbody2D rb;

    public Animator animatorObject;
    public Animator animatorShadow;
    public float heal = 1.0f;
    public Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        IDamageable damageableObject = collider.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            // After making sure the collider has a script that implements IDamagable, we can run the OnHeal implementation 
            damageableObject.OnHeal(heal);
            print("heal");
            col.enabled = false;
            animatorObject.SetBool("collected", true);
            animatorShadow.SetBool("collected", true);
            Invoke(nameof(OnObjectDestroy), 1);
        }
        
    }
    public void OnObjectDestroy()
    {
        Destroy(gameObject);
    }
}
