using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
    }
}
