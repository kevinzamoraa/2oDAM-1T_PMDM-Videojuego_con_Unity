using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    public int Respawn;
    void OnTriggerEnter2D(Collider2D other) {
        // Destroy(other.gameObject);
        SceneManager.LoadScene(Respawn);
    }
}
