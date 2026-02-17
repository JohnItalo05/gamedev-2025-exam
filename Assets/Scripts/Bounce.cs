using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Bounce : MonoBehaviour
{
    public float speedChangeAtPush;
    public float speedChangeAtHit;
    public Vector3 initialVelocity;
    public GameObject bonusText;
    public GameObject malusText;
    public Score scoreText;
    private Rigidbody body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.linearVelocity = initialVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        Vector3 bounceDirection = collision.contacts[0].normal;
        if (collision.collider.CompareTag("Player"))
        {
            // Give impulse (push by player) in direction of bounce at bouncing
            body.AddForce(bounceDirection * speedChangeAtPush, ForceMode.VelocityChange);

            // Earn a few points
            Score(10, collision.contacts[0].point);
        }
        else if (collision.collider.CompareTag("Destructible"))
        {
            // Give impulse (extra bounce due to hit) in direction of bounce at bouncing
            body.AddForce(bounceDirection * speedChangeAtHit, ForceMode.VelocityChange);

            // Hide the destructible object AT bouncing
            collision.collider.gameObject.GetComponent<Renderer>().enabled = false;

            // Earn fat points
            Score(50, collision.collider.gameObject.transform.position);
        }
        else if (collision.collider.CompareTag("Floor"))
        {
            // Lose many points
            Score(-100, collision.contacts[0].point);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Destructible"))
        {
            // Destroy the destructible object AFTER bouncing
            Destroy(collision.collider.gameObject, 0.1f);
        }
    }

    private void Score(int points, Vector3 scorePosition)
    {
        if (points > 0)
        {
            // Show bonus text
            GameObject textObj = Instantiate(bonusText, scorePosition, bonusText.transform.rotation);
            FloatingText floatingText = textObj.GetComponent<FloatingText>();
            floatingText.text = "+" + points.ToString();
        }
        else if (points < 0)
        {
            // Show malus text
            GameObject textObj = Instantiate(malusText, scorePosition, bonusText.transform.rotation);
            FloatingText floatingText = textObj.GetComponent<FloatingText>();
            floatingText.text = points.ToString().Replace("-", "–");
        }
        scoreText.currentScore += points;
    }
}
