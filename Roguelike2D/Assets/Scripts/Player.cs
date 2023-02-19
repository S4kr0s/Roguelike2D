using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //private AgentAnimations agentAnimations;

    //private AgentMover agentMover;

    [SerializeField] private InputActionReference movement, attack, pointerPosition;
    [SerializeField] private Vector2 pointerInput, movementInput;

    public Vector2 PointerInput => pointerInput;

    private WeaponParent weaponParent;

    private void Awake()
    {
        //agentAnimations = GetComponentsInChildren<AgentAnimations>();
        weaponParent = GetComponentInChildren<WeaponParent>();
        //agentMover = GetComponentsInChildren<AgentMover>();

        pointerPosition.asset.Enable();
    }

    private void Update()
    {
        pointerInput = GetPointerInput();
        weaponParent.PointerPosition = pointerInput;
        movementInput = movement.action.ReadValue<Vector2>().normalized;

        //agentMover.MovementInput = movementInput;

        //AnimateCharacter();
    }

    private void AnimateCharacter()
    {
        Vector2 lookDirection = pointerInput - (Vector2)transform.position;
        //agentAnimations.RotateToPointer(lookDirection);
        //agentAnimations.PlayAnimation(movementInput);
    }

    private Vector2 GetPointerInput()
    {
        Vector3 mousePos = pointerPosition.action.ReadValue<Vector2>();
        //Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
