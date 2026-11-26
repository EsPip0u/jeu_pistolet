using UnityEngine;
public class move : MonoBehaviour
{
    private CharacterController controller;
    private PlayerControl controls;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float speed;
    public bool grounded = false;
    private Vector3 velocity;
    public float gravity = -20f;
    public float jumpHeight = 1.2f;
    private void Awake()
    {
        controls = new PlayerControl();
        controller = GetComponent<CharacterController>();
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
        grounded = controller.isGrounded;
        
        if (grounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }
        Jump();
        velocity.y += gravity * Time.deltaTime;
        Run();
        Move();
        
        
    }
    void Move()
    {
        Vector2 input = controls.player.move.ReadValue<Vector2>();
        Vector3 direction = transform.right * input.x + transform.forward * input.y;
        direction = Vector3.Normalize(direction);
        Vector3 motion = direction * speed + Vector3.up * velocity.y;
        controller.Move(motion * Time.deltaTime);
    }
    void Run()
    {
        if (controls.player.run.ReadValue<float>() > 0)
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }   
    void Jump(){
        if (grounded && controls.player.jump.ReadValue<float>() > 0){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
   }
}