using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSpriteFlipper : MonoBehaviour
{
    public void OnMovementEvent(string eventName, float value)
    {
        if(eventName == "Horizontal")
        {
            if (value > 0)
            {
                transform.localScale = new Vector3 (1,1,1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }
}
