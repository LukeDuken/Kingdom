using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TopDownMovementController))]
public class Test_TopDownMovementController : MonoBehaviour
{
    [SerializeField] private Vector2 _setDirection = Vector2.zero;
    private TopDownMovementController _movementController;
    // Start is called before the first frame update
    private void Awake()
    {
        _movementController = GetComponent<TopDownMovementController>();
    }

    // Qua va bene l'update perchè il fixed update deve rimanere leggero e quindi
    // va chiamato solo quando aggiorna i dati che ci interessano puliti
    void Update()
    {
        //Chiamo il metodo move sul movement controller
        _movementController.Move(_setDirection);
    }
}
