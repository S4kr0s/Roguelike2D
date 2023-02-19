using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    /*
    public Vector2 PointerInput { get => pointerInput; set => pointerInput = value; }
    public Vector2 MovementInput { get => movementInput; set => movementInput = value; }

    [SerializeField] private AgentAnimations agentAnimations;
    [SerializeField] private AgentMover agentMover;
    [SerializeField] private WeaponParent weaponParent;
    [SerializeField] private Vector2 pointerInput, movementInput;

    private void Update()
    {
        agentMover.MovementInput = movementInput;
        weaponParent.PointerPosition = pointerInput;
        AnimateCharacter();
    }

    public void PerformAttack()
    {
        weaponParent.Attack();
    }

    private void Awake()
    {
        agentAnimations = GetComponentInChildren<AgentAnimations>();
        weaponParent = GetComponentInChildren<WeaponParent>();
        agentMover = GetComponentInChildren(AgentMover);
    }

    private void AnimateCharacter()
    {
        Vector2 lookDirection = pointerInput - (Vector2)transform.position;
        agentAnimations.RotateToPointer(lookDirection);
        agentAnimations.PlayAnimation(movementInput);
    }
    */

}
