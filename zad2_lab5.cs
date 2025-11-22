using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public float doorSpeed = 2f;
    public float openDistance = 3f;

    bool isMoving = false;
    bool isOpening = false;

    float closedPosition;
    float openedPosition;

    void Start()
    {
        closedPosition = transform.position.x;
        openedPosition = closedPosition + openDistance;
    }

    void Update()
    {
        if (!isMoving)
        {
            return;
        }

        if (isOpening && transform.position.x >= openedPosition)
        {
            isMoving = false;
        }
        else if (!isOpening && transform.position.x <= closedPosition)
        {
            isMoving = false;
        }

        if (isMoving)
        {
            float direction = isOpening ? 1f : -1f;
            Vector3 move = transform.right * direction * doorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOpening = true;
            isMoving = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOpening = false;
            isMoving = true;
        }
    }
}
