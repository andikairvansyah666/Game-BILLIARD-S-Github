using UnityEngine;

public class HoleController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TargetBall"))
        {
            Debug.Log("Bola masuk ke dalam lubang!");
            Destroy(other.gameObject);
        }
    }
}
