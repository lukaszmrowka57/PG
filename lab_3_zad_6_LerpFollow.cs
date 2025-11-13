using UnityEngine;

public class LerpFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;

    void Update()
    {
        float t = speed * Time.deltaTime;
        float newPosition = Mathf.Lerp(transform.position.y, target.position.y, t);
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
    }
}
