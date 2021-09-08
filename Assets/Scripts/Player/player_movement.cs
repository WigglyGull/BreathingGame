using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float speed;
    public Animator anim;

    // Update is called once per frame
    void Update()
    {
        bool left = Input.GetKey("a");
        bool right = Input.GetKey("d");

        Vector3 position = transform.position;

        if (left && position.x > -7.3f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("walking", true);
            position.x += -speed * Time.deltaTime;
        }

        if (right && position.x < 7.3f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("walking", true);
            position.x += speed * Time.deltaTime;
        }

        if (((right == false) && (left == false)) || (left && right) || ((position.x > 7.3f) || (position.x < -7.3f)))
        {
            anim.SetBool("walking", false);
        }

        transform.position = position;
    }
}
