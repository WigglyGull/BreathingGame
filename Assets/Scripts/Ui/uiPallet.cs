using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiPallet : MonoBehaviour{
    public bool left;
    public float startSpeed= 0.5f;
    public float speed;

    void Update(){
        speed = startSpeed;
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
            GameObject cam = GameObject.FindWithTag("MainCamera");
            camera_shake camShake = cam.GetComponent<camera_shake>();
            camShake.StartShake();

            GameObject ui = GameObject.FindWithTag("Kill");
            ui uiScript = ui.GetComponent<ui>();

            uiScript.life += 1;

            GameObject[] leftPallets = GameObject.FindGameObjectsWithTag("LeftPellet");
            foreach(GameObject pallet in leftPallets) GameObject.Destroy(pallet);
            GameObject[] rightPallets = GameObject.FindGameObjectsWithTag("RightPellet");
            foreach(GameObject pallet in rightPallets) GameObject.Destroy(pallet);
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Safe"){
            GameObject ui = GameObject.FindWithTag("Kill");
            GameObject boss = GameObject.FindWithTag("Boss");
            ui uiScript = ui.GetComponent<ui>();
            Boss bossScript = boss.GetComponent<Boss>();

            if(uiScript.button == "e" && Input.GetKey("e")){
                if(bossScript.breathing) uiScript.setButton(gameObject);
            }
            if(uiScript.button == "q" && Input.GetKey("q")){
                if(bossScript.breathing) uiScript.setButton(gameObject);
            }
        }
    }
    
    public void DestroyPallet(){
        Destroy(gameObject);
    }
}