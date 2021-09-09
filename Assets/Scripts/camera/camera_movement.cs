using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if ((player.position.x > -3.93) && (player.position.x < 3.93))
        {
            transform.position = new Vector3(player.position.x, 0, -10);
        }
    }
}
