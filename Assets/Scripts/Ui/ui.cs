using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui : MonoBehaviour{
    public GameObject buttonPrompt;
    public GameObject leftPallet;
    public GameObject rightPallet;

    public Transform leftSpawn;
    public Transform rightSpawn;

    public string button = "e";

    public Sprite E;
    public Sprite Q;

    float startPalletTimer = 2;
    float palletTimer;

    SpriteRenderer spButton;

    void Start(){
        palletTimer = startPalletTimer;
        spButton = buttonPrompt.GetComponent<SpriteRenderer>();
    }

    void Update(){
        if(palletTimer <= 0){
            palletTimer = startPalletTimer;
            spawnPallets();
        }else palletTimer -= 1 * Time.deltaTime;
    }

    void spawnPallets(){
        Instantiate(leftPallet, rightSpawn);
        Instantiate(rightPallet, leftSpawn);
    }

    public void setButton(GameObject pallet){
        Debug.Log("working");
        if(button == "e"){
            button = "q";
            spButton.sprite = Q;
        }else if(button == "q"){
            button = "e";
            spButton.sprite = E;
        }
        Destroy(pallet);
    }
}
