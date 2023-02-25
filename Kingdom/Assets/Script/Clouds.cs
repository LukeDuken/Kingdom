using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    private float lenght, startPos;
    public float CloudSpeed;

    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float temp = (transform.position.x * (1 - parallaxEffect));
        float dist = (transform.position.x + (CloudSpeed * Time.deltaTime));


        transform.position = new Vector2(startPos + dist, transform.position.y);
        //transform.position = new Vector2(startPos + dist + (parallaxEffect * Time.deltaTime), transform.position.y);
        //transform.position = new Vector2(transform.position.x + (parallaxEffect * Time.deltaTime), transform.position.y);


        if (dist > startPos + lenght) 
        {
            //startPos += lenght;
            transform.position = new Vector2(startPos, transform.position.y);
          
        }
        
    }
}
