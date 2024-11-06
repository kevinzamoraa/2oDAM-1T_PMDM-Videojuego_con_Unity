using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;

    void FixedUpdate()
    {
        if (Player != null)
        {
            Vector3 position = transform.position;
            position.x = Player.position.x;
            position.y = Player.position.y;
            transform.position = position;
        }
    }
}
