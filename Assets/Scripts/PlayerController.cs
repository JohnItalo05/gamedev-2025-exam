using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float sprintForce;
    private Rigidbody body;
    private Animator animator;  
    private bool isFacingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
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
        animator.SetFloat("Speed_f", Mathf.Abs(horizontalInput)); // Mathf.Abs(x) is always >= 0        
    }

    private void Turn()
    {
        transform.Rotate(Vector3.up, 180);
    }
}
