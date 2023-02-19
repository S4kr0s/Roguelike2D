using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidanceBehaviour : SteeringBehaviour
{
    [SerializeField] private float radius, agentColliderSize = 0.6f;

    [SerializeField] private bool showGizmo = true;

    // Gizmo Param
    float[] dangersResultTemp = null;

    public override (float[] danger, float[] interest) GetSteering(float[] danger, float[] interest, AIData aIData)
    {
        foreach (Collider2D obstacleCollider in aIData.obstacles)
        {
            Vector2 directionToObstacle = obstacleCollider.ClosestPoint(transform.position) - (Vector2)transform.position;
            float distanceToObstace = directionToObstacle.magnitude;

            // Calculate Weight based on the distance from Enemy to Obstacle
            float weight = distanceToObstace <= agentColliderSize ? 1 : (radius - distanceToObstace) / radius;
            Vector2 directionToObstacleNormalized = directionToObstacle.normalized;

            // Add Obstacle Params to Danger Array
            for (int i = 0; i < Direction2D.eightDirectionsListNormalized.Count; i++)
            {
                float result = Vector2.Dot(directionToObstacleNormalized, Direction2D.eightDirectionsListNormalized[i]);
                float valueToPutIn = result * weight;

                if (valueToPutIn > danger[i])
                {
                    danger[i] = valueToPutIn;
                }
            }
        }
        dangersResultTemp = danger;
        return (danger, interest);
    }

    private void OnDrawGizmos()
    {
        if (showGizmo == false) return;

        if (Application.isPlaying && dangersResultTemp != null)
        {
            if (dangersResultTemp != null)
            {
                Gizmos.color = Color.red;
                for (int i = 0; i < dangersResultTemp.Length; i++)
                {
                    Gizmos.DrawRay(transform.position, Direction2D.eightDirectionsListNormalized[i] * dangersResultTemp[i]);
                }
            }
        }
        else
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
