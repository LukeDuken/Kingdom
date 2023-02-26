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
        //get the x lenght of the cloud sprite
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //calculate the distance over time it moves
        float dist = (transform.position.x + (CloudSpeed * Time.deltaTime));

        //move it 
        transform.position = new Vector2(startPos + dist, transform.position.y);
        

        // if the distance becomes major of the start position + the lenght of the sprite
        if (dist > startPos + lenght) 
        {
            //Reset the position to the origin with a pixel pefeect transition
            transform.position = new Vector2(startPos, transform.position.y);
          
        }
        
    }
}
