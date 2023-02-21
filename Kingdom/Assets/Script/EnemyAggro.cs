using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAggro : MonoBehaviour
{
    public string tagTarget = "Player";
    public List<Collider2D> detectObjs = new List<Collider2D>();
    public Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    //Detect when Objects enters range
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == tagTarget)
        {
            detectObjs.Add(collider);
        }
    }

    // Detect when Objects leave range
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == tagTarget)
        {
            detectObjs.Remove(collider);
        }
    }
}
