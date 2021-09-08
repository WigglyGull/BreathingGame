using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiPallet : MonoBehaviour{
    public bool left;
    public float speed;

    void Update(){
        if(left) changePos(-1f);
        else if(!left) changePos(1f);
    }

    void changePos(float amount){
        float position = transform.position.x;

        position += amount * Time.deltaTime * speed;
        transform.position = new Vector3(position, transform.position.y, -2);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Kill"){
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other){
            if(other.tag == "Safe"){
                GameObject ui = GameObject.FindWithTag("Kill");
                ui uiScript = ui.GetComponent<ui>();

                if(uiScript.button == "e" && Input.GetKey("e")){
                    uiScript.setButton(gameObject);
                }
                if(uiScript.button == "q" && Input.GetKey("q")){
                    uiScript.setButton(gameObject);
                }
            }
        }
}