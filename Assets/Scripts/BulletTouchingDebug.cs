using UnityEngine;

public class BulletTouchingDebug : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Bullet touched {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Portal") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            
        }
        else{
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}