using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public interface IMover 
{
    //come fixed update per i movimenti
    public void PerformMovement();
    public void SetMovementDirection(Vector2 direction);
    public bool ShouldActivate();

}
