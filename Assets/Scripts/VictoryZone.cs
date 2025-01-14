using UnityEngine;

public class VictoryZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        Application.Quit();
    }
}
