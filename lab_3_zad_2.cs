using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = 2.0f;
    public float distance = 10f;

    private Vector3 startPosition;
    private int direction = 1; 

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        
        float moveX = speed * Time.deltaTime * direction;
        transform.Translate(moveX, 0f, 0f, Space.World);

        
        float offset = transform.position.x - startPosition.x;

        if (direction == 1 && offset >= distance)
        {
            
            transform.position = new Vector3(startPosition.x + distance, transform.position.y, transform.position.z);
            direction = -1;
        }
        else if (direction == -1 && offset <= 0f)
        {
            
            transform.position = new Vector3(startPosition.x, transform.position.y, transform.position.z);
            direction = 1;
        }
    }
}
