using UnityEngine;

public class AdjustGravity : MonoBehaviour
{
    public float gravityFactor = 1f;
    
    void Start()
    {
        Physics.gravity *= gravityFactor;
    }
}
