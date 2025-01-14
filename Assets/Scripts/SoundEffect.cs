using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundController.Instance.PlaySound(audioClip);
            Destroy(gameObject);
        }
    }
}
