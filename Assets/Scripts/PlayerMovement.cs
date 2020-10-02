using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody player;
    public float rotationSpeed = 100f;
    public float moveSpeed = 100f;
    public float jumpForce = 300f;
    public float slide = 0.5f;
    public Animator animator;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }
    void FixedUpdate()
    {
        if (isGrounded())
        {
            if (Input.GetKey("w"))
            {
                player.AddForce(transform.forward * moveSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey("s"))
            {
                player.AddForce(transform.forward * -moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey("d"))
            {
                player.AddForce(transform.right * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKey("a"))
            {
                player.AddForce(transform.right * -moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
            }
            if (Input.GetKeyUp("w") || Input.GetKeyUp("s") || Input.GetKeyUp("d") || Input.GetKeyUp("a"))
            {
                player.AddForce(-player.velocity.x * slide, 0, -player.velocity.z * slide, ForceMode.VelocityChange);
            }
            
        }
        transform.Rotate(Vector3.up, Input.GetAxisRaw("Mouse X") * rotationSpeed * Time.deltaTime);
    }

    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            player.velocity = Vector3.zero;
            transform.position = startPosition;
            transform.rotation = startRotation;
        }
        if (isGrounded() && Input.GetKeyDown("space"))
        {
            animator.SetBool("IsJumping", true);
        }
        if (Input.GetKeyUp("space") && animator.GetBool("IsJumping"))
        {
            if (isGrounded()) 
            {
                float jumpStrenght = Mathf.Clamp01(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
                player.AddForce(transform.up * jumpForce * jumpStrenght, ForceMode.Impulse);
            }            
            animator.SetBool("IsJumping", false);
        }
    }

    private bool isGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<groundCheck>().isGrounded;
    }
}
