using UnityEngine;
using UnityEngine.UI;

public class TokenController : MonoBehaviour
{
    public int tokenCount;
    public Text tokenText;
    public AudioClip audio;

    void Update()
    {
        tokenText.text = $"Tokens: {tokenCount}";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SoundController.Instance.PlayAudioClip(audio);
            Destroy(gameObject);
        }
    }
}
