using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleEnemyAI : MonoBehaviour
{
    [SerializeField] private List<Detector> detectors;
    [SerializeField] private List<SteeringBehaviour> steeringBehaviours; 
    [SerializeField] private AIData aiData;
    [SerializeField] private float detectionDelay = 0.05f, aiUpdateDeleay = 0.06f, attackDelay = 1f;
    [SerializeField] private float attackDistance = 0.5f;

    public UnityEvent OnAttackPressed;
    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;

    [SerializeField] private Vector2 movementInput;

    [SerializeField] private ContextSolver movementDirectionSolver;

    bool following = false;

    private void Start()
    {
        InvokeRepeating("PerformDetection", 0, detectionDelay);
    }

    private void PerformDetection()
    {
        foreach (Detector detector in detectors)
        {
            detector.Detect(aiData);
        }
    }

    private void Update()
    {
        if (aiData.currentTarget != null)
        {
            OnPointerInput?.Invoke(aiData.currentTarget.position);
            if (following == false)
            {
                following = true;
                StartCoroutine(ChaseAndAttack());
            }
        }
        else if (aiData.GetTargetsCount() > 0)
        {
            aiData.currentTarget = aiData.targets[0];
        }
        OnMovementInput?.Invoke(movementInput);
    }

    private IEnumerator ChaseAndAttack()
    {
        if (aiData.currentTarget == null)
        {
            movementInput = Vector2.zero;
            following = false;
            yield return null;
        }
        else
        {
            float distance = Vector2.Distance(aiData.currentTarget.position, transform.position);

            if (distance < attackDistance)
            {
                movementInput = Vector2.zero;
                OnAttackPressed?.Invoke();
                yield return new WaitForSeconds(attackDelay);
                StartCoroutine(ChaseAndAttack());
            }
            else
            {
                movementInput = movementDirectionSolver.GetDirectionToMove(steeringBehaviours, aiData);
                yield return new WaitForSeconds(aiUpdateDeleay);
                StartCoroutine(ChaseAndAttack());
            }
        }
    }
}
