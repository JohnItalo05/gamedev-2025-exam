using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public string text;
    public Color color;
    public float verticalSpeed;
    public float fadeDuration;
    private TextMeshPro tmp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tmp = GetComponent<TextMeshPro>();
        tmp.text = text;
        tmp.faceColor = color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);

        // Fade out faceColor over time
        Color currentColor = tmp.faceColor; // a temporary variable is necessary
        float alphaDecrease = Time.deltaTime / fadeDuration; // longer frame = longer fade
        currentColor.a -= alphaDecrease;
        tmp.faceColor = currentColor;

        // Destroy when fading is complete
        if (tmp.faceColor.a <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
