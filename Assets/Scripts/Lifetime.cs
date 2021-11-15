using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float timeLimit = 2;

    void Start()
    {
        Invoke("Die", timeLimit);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
