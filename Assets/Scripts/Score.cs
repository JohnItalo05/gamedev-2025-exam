using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int currentScore = 0;
    private TextMeshProUGUI label;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore >= 0)
        {
            label.text = "score: " + currentScore.ToString();
        } 
        else
        {
            label.text = "score: " + currentScore.ToString().Replace("-", "–");
        }
    }
}
