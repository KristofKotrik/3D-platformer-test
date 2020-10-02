using UnityEngine;

public class JumpBoostPadBeh : MonoBehaviour
{
    public float BoostForce = 25f;
    private bool HasPlayer = false;
    private Rigidbody Player;

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.rigidbody.CompareTag("Player") && collision.GetContact(0).normal == Vector3.down)
        {
            HasPlayer = true;
            Player = collision.rigidbody;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player"))
        {
            HasPlayer = false;
        }
    }

    private void Update()
    {
        if (HasPlayer && Input.GetKeyUp("space"))
        {
            Player.AddForce(Vector3.up * BoostForce, ForceMode.VelocityChange);
        }
    }
}
