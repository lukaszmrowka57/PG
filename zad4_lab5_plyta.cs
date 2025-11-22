using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float multiplier = 3f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MoveWithCharacterController controller = other.gameObject.GetComponent<MoveWithCharacterController>();
            if (controller != null)
            {
                controller.SuperJump(multiplier);
            }
        }
    }
}
