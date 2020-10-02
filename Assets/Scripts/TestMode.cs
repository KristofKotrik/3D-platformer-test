using UnityEngine;

public class TestMode : MonoBehaviour
{
    private bool testMode = false;
    private Vector3 StartPosition = Vector3.zero;
    private Vector3 JumpPosition = Vector3.zero;
    private bool inAir = false;
    private float maxHeight = 0f;
    private float maxDistance = 0f;
    void FixedUpdate()
    {
        if (testMode)
        {
            if (transform.position.y - StartPosition.y > maxHeight)
            {
                maxHeight = transform.position.y - StartPosition.y;
            }
        }


    }

    void Update()
    {
        if (inAir && isGrounded() && testMode)
        {
            inAir = false;
            maxDistance = Mathf.Sqrt(Mathf.Pow(JumpPosition.x - transform.position.x, 2) + Mathf.Pow(JumpPosition.z - transform.position.z, 2));
        }
        if (isGrounded() && Input.GetKeyDown("space"))
        {
            if (testMode)
            {
                JumpPosition = transform.position;
                inAir = true;
            }
        }
        if (Input.GetKeyDown("t"))
        {
            testMode = !testMode;
            if (testMode)
            {
                Debug.Log("TEST MODE ON");
                StartPosition = transform.position;
                maxHeight = 0f;
                maxDistance = 0f;
            }
            else
            {
                Debug.Log("Max Height: " + maxHeight);
                Debug.Log("Max Distance: " + maxDistance);
                Debug.Log("TEST MODE OFF");
            }

        }
    }
    private bool isGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<groundCheck>().isGrounded;
    }
}
