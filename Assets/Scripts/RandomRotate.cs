using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    public float maxRotationSpeed;
    private float rotationSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        InvokeRepeating(nameof(ChangeDirection), 5f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
    private void ChangeDirection()
    {
        if (rotationSpeed > 0)
        {
            rotationSpeed = Random.Range(-maxRotationSpeed, 0);
        }
        else
        {
            rotationSpeed = Random.Range(0, maxRotationSpeed);
        }
    }
}
