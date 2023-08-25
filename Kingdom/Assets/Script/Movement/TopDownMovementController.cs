using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//questo attributo fa si che se aggiungo questo componente ad un oggetto l'attributo me lo aggiunge automaticamente
[RequireComponent(typeof(Rigidbody2D))]
public class TopDownMovementController : MonoBehaviour
{
    //Le variabili definite all'inizia della classe sono campi _camelCase
    private Rigidbody2D _rigidBody;

    private Vector2 _currentRequiredDirection;

    //Come serialize field posso modificare da editor ma non ci accedo da altri metodi 
    [SerializeField] float _moveSpeed = 1f;

    //direction è una variabile di tipo argomento
    //questo metodo ha la variabile generica tra parentesi perchè viene definita dai componenti che usano questo metodo.
    //questo è una figata in quanto rende il metodo generico e utilizzabile da terzi
    public void Move(Vector2 direction)
    {
        // int a = 0 definita dentro il metodo è una variabile locale
        // vogliamo che l'input non sia maggiore di uno inoltre fa si che i movimenti diagonali siano alla stessa velocità
        //se l'input è maggire di uno clampa ad uno altrimenti si prende quello che è, e poi lo moltiplica per la direzione scelta
        _currentRequiredDirection = Mathf.Clamp(direction.magnitude, 0, 1) * direction.normalized;
    }
    // Quando devi prendere altri componenti da un oggetto il punto migliore è nell'awake che avviene prima dello start
    // è meglio ribadire che è un metodo privato, tutti i metodi di unity sono privati
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_currentRequiredDirection != Vector2.zero)
        {
            _rigidBody.MovePosition((Vector2)transform.position +(_currentRequiredDirection * _moveSpeed * Time.fixedDeltaTime));
            //Sono sicuro che il personaggio non si muove se non viene chiamato il metodo in questo frame
            _currentRequiredDirection = Vector2.zero;
        }
    }
}
