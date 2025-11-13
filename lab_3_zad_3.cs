using UnityEngine;

public class MoveCubeSquare : MonoBehaviour
{
    public float speed = 2.0f;
    public float sideLength = 10f;

    private float distanceMoved;

    void Start()
    {
        distanceMoved = 0f;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        float remaining = sideLength - distanceMoved;

        if (step > remaining)
            step = remaining;

        transform.Translate(transform.forward * step, Space.World);
        distanceMoved += step;

        if (distanceMoved >= sideLength - 0.0001f)
        {
            distanceMoved = 0f;
            transform.Rotate(0f, 90f, 0f);
        }
    }
}
