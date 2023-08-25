using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(TopDownMovementController))]
public class PlayerControllerNew : MonoBehaviour, PlayerInput_Actions.IPlayerActions
{
    private PlayerInput_Actions _playerInput_Actions;
    private TopDownMovementController _movementController;
    // Start is called before the first frame update
    private void Awake()
    {
        _playerInput_Actions = new PlayerInput_Actions();
        _movementController = GetComponent<TopDownMovementController>();

    }

    // Update is called once per frame
    private void OnEnable()
    {
        _playerInput_Actions.Player.Enable();
        //Setcallback ha bisogno di una interfaccia di Iplayeraction per registrare i metodi da chiamare quando si verifica l'input
        //senza questo setcallback gli eventi sotto non vengono chiamati da input
        _playerInput_Actions.Player.SetCallbacks(this);
    }
    private void OnDisable()
    {
        _playerInput_Actions.Player.Disable();
        //Removecallback serve a smettere di chiamare i metodi dell'interfaccia
        _playerInput_Actions.Player.RemoveCallbacks(this);
    }

    private void Update()
    {
        //chiamiamo l'input in update perchè viene utilizzato sempre anche se rimane lo stesso
        var direction = _playerInput_Actions.Player.Move.ReadValue<Vector2>();
        _movementController.Move(direction);
    }

    //questi metodi sono derivati dall'utilizzo dell'interfaccia di Unity Input system
    public void OnMove(InputAction.CallbackContext context)
    {
        
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        //throw new System.NotImplementedException();
    }
}
