using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool movingEnabled = false;
    [SerializeField] private bool rollingEnabled = false;
    [SerializeField] private bool dashingEnabled = false;

    [Header("Properties")]
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private new Rigidbody2D rigidbody2D;
    [SerializeField] private Vector2 movement;

    private void Awake()
    {
        if (rigidbody2D == null)
            rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (movingEnabled)
            rigidbody2D.MovePosition(rigidbody2D.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);
    }
}
