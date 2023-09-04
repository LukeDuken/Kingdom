using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPriorityHandler : MonoBehaviour
{
    [SerializeField] Component[] _movementControllers;
    public void SetDirection(Vector2 direction)
    {
        foreach(IMover controller in _movementControllers)
        {
            controller.SetMovementDirection(direction);
        }
    }

    private void FixedUpdate()
    {
        foreach (IMover controller in _movementControllers)
        {
            if(controller.ShouldActivate())
            {
                controller.PerformMovement();
                //il return serve a uscire dal metodo in modo tale che al primo positivo non esegua anche gli altri.
                return;
            }
        }
    }
}
