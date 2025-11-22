using UnityEngine;

public class WaypointPlatform : MonoBehaviour
{
    public Transform[] waypoints;
    public float platformSpeed = 2f;

    bool isRunning = false;
    int currentIndex = 0;
    int direction = 1;

    void Update()
    {
        if (!isRunning || waypoints == null || waypoints.Length == 0)
        {
            return;
        }

        Vector3 target = waypoints[currentIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, target, platformSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            if (currentIndex == waypoints.Length - 1)
            {
                direction = -1;
            }
            else if (currentIndex == 0)
            {
                direction = 1;
            }

            currentIndex += direction;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isRunning = true;
            other.transform.SetParent(transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}
