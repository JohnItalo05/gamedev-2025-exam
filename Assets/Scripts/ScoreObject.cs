using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    [Header("Score Settings")]
    public int points;         
    public bool destroyOnHit = true; 

    public int GetPoints()
    {
        return points;
    }

    public void OnCollected()
    {
        if (destroyOnHit)
        {
            Destroy(gameObject);
        }
    }
}
