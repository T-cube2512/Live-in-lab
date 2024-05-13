using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public float rotationSpeed = 100.0f;

    void Update()
    {
        // Calculate rotation based on input
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        // Rotate the camera around the Y-axis
        transform.Rotate(Vector3.up, rotation);
    }
}
