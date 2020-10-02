using UnityEngine;

public class pitch : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float topAngle = 85f;
    public float bottomAngle = 350f;

    // Update is called once per frame
    void FixedUpdate()
    {
        float yaxis = Input.GetAxisRaw("Mouse Y");
        float eulerX = transform.rotation.eulerAngles.x;

        if (eulerX <= topAngle || eulerX > bottomAngle || (eulerX <= 180 && yaxis > 0) || (eulerX > 180 && yaxis < 0))
        {
            transform.Rotate(Vector3.left, yaxis * rotationSpeed * Time.deltaTime);
        }
        
    }
}
