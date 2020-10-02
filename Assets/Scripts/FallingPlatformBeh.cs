using UnityEngine;

public class FallingPlatformBeh : MonoBehaviour
{
    public float FallDelay = 1f;
    public float ResetDelay = 3f;
    public bool NoRotation = false;
    public bool Respawn = true;
    public Animator animator;
    private Vector3 OriginalPositon;
    private Quaternion OriginalRotation;
    private Rigidbody ThisPlatform;
    private BoxCollider ThisCollider;

    private void Start()
    {
        ThisPlatform = GetComponent<Rigidbody>();
        ThisCollider = GetComponent<BoxCollider>();
        OriginalPositon = transform.position;
        OriginalRotation = transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody == null)
        {
            return;
        }
        if(collision.rigidbody.CompareTag("Player"))
        {
            if (FallDelay > 0)
            {
                Invoke("Fall", FallDelay);
            }
            else
            {
                Fall();
            }
        }
        
    }

    private void Fall()
    {
        if (NoRotation)
        {
            ThisPlatform.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            ThisPlatform.constraints = RigidbodyConstraints.None;
        }
        animator.SetTrigger("Falling");
        if (Respawn)
        {
            Invoke("ResetPosition", ResetDelay);
            Invoke("DisableCollision", .3f);
        }
        else
        {
            Invoke("RemoveSelf", .3f);
        }
        
    }

    private void ResetPosition()
    {
        ThisPlatform.constraints = RigidbodyConstraints.FreezeAll;
        transform.position = OriginalPositon;
        transform.rotation = OriginalRotation;
        ThisCollider.enabled = true;
        animator.SetTrigger("Respawning");
        
    }

    private void DisableCollision()
    {
        ThisCollider.enabled = false;
    }
    private void RemoveSelf()
    {
        Destroy(gameObject);
    }
}
