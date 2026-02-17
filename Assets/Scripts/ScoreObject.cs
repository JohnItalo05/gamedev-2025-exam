using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    [Header("Score Settings")]
    public int points = 50;          // Punti assegnati
    public bool destroyOnHit = true; // Distrugge l'oggetto dopo la collisione

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
