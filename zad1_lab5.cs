using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    public float platformSpeed = 2f;
    public float distance = 6.6f;

    bool isRunning = false;
    bool isRunningForward = true;
    bool isRunningBackward = false;

    float startPosition;
    float endPosition;

    void Start()
    {
        startPosition = transform.position.x;
        endPosition = transform.position.x + distance;
    }

    void Update()
    {
        if (isRunningForward && transform.position.x >= endPosition)
        {
            isRunning = false;
        }
        else if (isRunningBackward && transform.position.x <= startPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.right * platformSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.position.x >= endPosition)
            {
                isRunningBackward = true;
                isRunningForward = false;
                platformSpeed = -platformSpeed;
            }
            else if (transform.position.x <= startPosition)
            {
                isRunningForward = true;
                isRunningBackward = false;
                platformSpeed = Mathf.Abs(platformSpeed);
            }
            isRunning = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z platformy.");
        }
    }
}
