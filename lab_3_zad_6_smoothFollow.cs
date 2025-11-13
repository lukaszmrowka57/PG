using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    float yVelocity = 0f;

    void Update()
    {
        float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
    }
}
