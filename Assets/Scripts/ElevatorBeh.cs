using UnityEngine;

public class ElevatorBeh : MonoBehaviour
{
    public float MaxHeight = 13f;
    public float MinHeight = 0.5f;
    public float ElStep = 20f;
    public Transform Player;
    private bool HasPlayer = false;

    private void FixedUpdate()
    {
        if (HasPlayer && transform.position.y <= MaxHeight)
        {
            transform.Translate(new Vector3(0, ElStep * Time.deltaTime, 0));
            Player.Translate(new Vector3(0, ElStep * Time.deltaTime, 0));
        }
        if(!HasPlayer && transform.position.y >= MinHeight)
        {
            transform.Translate(new Vector3(0, -ElStep * Time.deltaTime, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player") && collision.GetContact(0).normal == Vector3.down)
        {
            HasPlayer = true;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player"))
        {
            HasPlayer = false;
        }
    }
}
