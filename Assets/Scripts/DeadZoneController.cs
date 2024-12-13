using UnityEngine;

public class DeathZoneController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Collider>().GetComponent<Player>();
        if (player != null)
        {
            player.Die();
        }
    }
}
