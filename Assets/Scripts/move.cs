using UnityEngine;

public class move : MonoBehaviour
{

    public Rigidbody rb;
    public float force = -100;
    public move movement;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, force * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        movement.enabled = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
