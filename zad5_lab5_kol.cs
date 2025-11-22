using UnityEngine;

public class ObstacleContact : MonoBehaviour
{
    public string obstacleTag = "Obstacle";

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag(obstacleTag))
        {
            Debug.Log("Player wszedł w kontakt z przeszkodą.");
        }
    }
}
