using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DodgeController : MonoBehaviour, IMover
{
    //Le variabili definite all'inizia della classe sono campi _camelCase
    private Rigidbody2D _rigidBody;

    public Vector2 _currentRequiredDirection;
    private float _timer = 0f;
    public Vector2 _lastReceivedDirection;
    //Come serialize field posso modificare da editor ma non ci accedo da altri metodi
    [SerializeField] private float _dodgeDistance = 1f;
    [SerializeField] private float _dodgeDuration = 1f;
    // Start is called before the first frame update
    public void Dodge()
    {
        if (_timer > 0)
        {
            return;
        }
        //direction is defined in player controller from input interface
        _currentRequiredDirection = _lastReceivedDirection;
        _timer = _dodgeDuration;
    }

    public void PerformMovement()
    {
        if (_currentRequiredDirection != Vector2.zero)
        {
            _rigidBody.MovePosition((Vector2)transform.position + (_currentRequiredDirection * (_dodgeDistance / _dodgeDuration) * Time.fixedDeltaTime));

        }
        _timer -= Time.fixedDeltaTime;
    }

    public void SetMovementDirection(Vector2 direction)
    {
        if (direction.magnitude > 0.2)
        {
            //questo supporta solo il pad e non la tastiera da INVESTIGARE
            _lastReceivedDirection = direction.normalized;
        }
    }

    public bool ShouldActivate()
    {
        //viene prima valutato se timer è maggiore di zero e in base alla veridicità dell'affermazione gestiamo il booleano
        return _timer > 0;
    }

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

}
