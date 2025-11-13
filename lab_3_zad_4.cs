using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 5f;

    Rigidbody rb;
    Vector3 input;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");
        input = new Vector3(mH, 0f, mV);
    }

    void FixedUpdate()
    {
        Vector3 direction = input.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + direction);
    }
}
