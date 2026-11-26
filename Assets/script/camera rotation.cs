using UnityEngine;
using UnityEngine.InputSystem;
public class cameraRotation : MonoBehaviour
{
    public float mouseSensitivity = 0.85f;
    float xRotation = 0f;
    void Start()
    {
        xRotation = 0f;
        Cursor.lockState = CursorLockMode.Locked;
        xRotation = transform.localEulerAngles.x;
    }
    void Update()
    {
        if (!enabled) return;
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        float mouseX = mouseDelta.x * mouseSensitivity;
        float mouseY = mouseDelta.y * mouseSensitivity;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}