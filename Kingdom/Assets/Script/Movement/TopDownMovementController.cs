using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//questo attributo fa si che se aggiungo questo componente ad un oggetto l'attributo me lo aggiunge automaticamente
[RequireComponent(typeof(Rigidbody2D))]
public class TopDownMovementController : MonoBehaviour, IMover 
{
    public UnityEvent<string,float> MovementEvent;
    //Le variabili definite all'inizia della classe sono campi _camelCase
    private Rigidbody2D _rigidBody;
    private Vector2 _currentRequiredDirection;

    //Come serialize field posso modificare da editor ma non ci accedo da altri metodi 
    [SerializeField] float _moveSpeed = 1f;

    public void PerformMovement()
    {
        if (_currentRequiredDirection != Vector2.zero)
        {
            _rigidBody.MovePosition((Vector2)transform.position + (_currentRequiredDirection * _moveSpeed * Time.fixedDeltaTime));
        }
    }

    public void SetMovementDirection(Vector2 direction)
    {
        //direction is defined in player controller from input interface
        _currentRequiredDirection = Mathf.Clamp(direction.magnitude, 0, 1) * direction.normalized;
        //il punto interrogativo è per non chiamare il metodo se è null
        MovementEvent?.Invoke("Horizontal",direction.x);
        MovementEvent?.Invoke("Vertical", direction.y);
        MovementEvent?.Invoke("Speed", _currentRequiredDirection.magnitude *_moveSpeed);
    }

    public bool ShouldActivate()
    {
        //because this is the last movement the system will check it will be always true
        return true;
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
}
