using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour{
    public Animator anim;
    public SpriteRenderer distanceSp;
    public float duration;    //the max time of a walking session (set to ten)
    public float speed;

    float elapsedTime = 0f; //time since started walk
    float wait = 0f; //wait this much time
    float waitTime = 0f; //waited this much time

    bool breathingRight;
    bool breathingLeft;
    public bool breathing;

    float randomX;  //randomly go this X direction
    float randomZ;  //randomly go this Z direction

    bool move = true; //start moving

    void Start(){
        randomX = Random.Range(-3, 3);
        randomZ = Random.Range(-3, 3);
    }

    void Update(){
        GameObject player = GameObject.Find("Player");
        float distance = Vector2.Distance(this.transform.position, player.transform.position);

        if (distance < 1.4) breathing = true;
        else breathing = false;

        if (elapsedTime < duration && move){
            Vector3 characterScale = transform.localScale;

            characterScale.x = (randomX < 0) ? 1 : -1;
            transform.localScale = characterScale;
            
            if (this.transform.position.x > 7) randomX *= -1;
            else if (this.transform.position.x < -7) randomX *= -1;
            
            
            transform.Translate(new Vector2(randomX, 0) * Time.deltaTime * speed);
            elapsedTime += Time.deltaTime;
            if(randomX != 0) anim.SetBool("Walking", true);
            else anim.SetBool("Walking", false);
        }else{
            move = false;
            wait = Random.Range(1, 3);
        }

        if (waitTime < wait && !move){
            waitTime += Time.deltaTime;
            anim.SetBool("Walking", false);
        }else if (!move){
            move = true;
            elapsedTime = 0f;
            randomX = Random.Range(-2, 2);
        }

        if(breathing) distanceSp.color = Color.white;
        else distanceSp.color = Color.red;
    }
}