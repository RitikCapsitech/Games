using UnityEngine;

public class FallDestroy : MonoBehaviour
{
    private Score scoreManager;

    private void Start()
    {
        // find the Score script in the scene
        scoreManager = FindObjectOfType<Score>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy if it hits the Ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (scoreManager != null)
                scoreManager.AddPoints(gameObject.tag);
            
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Destroy if it falls out of screen (below Y = -6)
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
