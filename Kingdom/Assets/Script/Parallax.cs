using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cam;
    public float relativeMoveX = 0.3f;
    public float relativeMoveY = 0.3f;
    public bool lockY = false;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(cam.position.x * relativeMoveX, cam.position.y * relativeMoveY);
    }
}
