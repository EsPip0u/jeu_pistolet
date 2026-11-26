using UnityEngine;
using UnityEngine.InputSystem;
public class cameraRotation : MonoBehaviour
{
    public Transform cameraHolder;
    private PlayerControl controls;
    public float sensitivity = 0.1f;
    public float xrotation = 0f;
    private void Awake()
    {
        controls = new PlayerControl();
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
        void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }
    void Update()
    {
        Vector2 look = controls.player.look.ReadValue<Vector2>() * sensitivity;

        transform.Rotate(Vector3.up * look.x);

        xrotation -= look.y;
        xrotation = Mathf.Clamp(xrotation, -85f, 85f);
        cameraHolder.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
    }
}