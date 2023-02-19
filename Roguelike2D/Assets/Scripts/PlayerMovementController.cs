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
        {
            // MovePosition ignores Collisions
            // rigidbody2D.MovePosition(rigidbody2D.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);

            Vector2 desiredPosition = rigidbody2D.position + movement.normalized * movementSpeed * Time.fixedDeltaTime;
            Vector2 direction = new Vector2(desiredPosition.x - rigidbody2D.position.x, desiredPosition.y - rigidbody2D.position.y);
            Ray ray = new Ray(rigidbody2D.position, direction);
            RaycastHit raycastHit;
            if (!Physics.Raycast(ray, out raycastHit, direction.magnitude))
                rigidbody2D.MovePosition(desiredPosition);
            else
                rigidbody2D.MovePosition(raycastHit.point);
        }
    }
}
