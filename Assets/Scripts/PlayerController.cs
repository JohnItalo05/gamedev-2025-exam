using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float sprintForce;
    public float jumpForce;

    private Rigidbody body;
    private Animator animator;
    private bool isFacingRight = true;
    private bool isGrounded; 

   private void Start()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Mathf.Abs(body.linearVelocity.y) < 0.01f;

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump_t");
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.AddForce(horizontalInput * sprintForce * Vector3.right);

        if (isFacingRight && horizontalInput < 0)
        {
            Turn();
            isFacingRight = false;
        }
        else if (!isFacingRight && horizontalInput > 0)
        {
            Turn();
            isFacingRight = true;
        }

        animator.SetFloat("Speed_f", Mathf.Abs(horizontalInput));
    }

    private void Turn()
    {
        transform.Rotate(Vector3.up, 180);
    }
}