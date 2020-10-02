using UnityEngine;

public class groundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    public bool isGrounded;
    private void OnTriggerStay(Collider other)
    {
        isGrounded = other != null && (((1 << other.gameObject.layer) & groundMask) != 0);

    }
    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
