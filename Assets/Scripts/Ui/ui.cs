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

    public float startPalletTimer = 2;
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
        if(button == "e"){
            button = "q";
            spButton.sprite = Q;
        }else if(button == "q"){
            button = "e";
            spButton.sprite = E;
        }

        destoryOppPallet(pallet);
        Destroy(pallet);
    }

    public void destoryOppPallet(GameObject pallet){
        if(pallet.tag == "LeftPellet"){
            Transform oppsitePallet = leftSpawn.GetChild(0);
            uiPallet pallScript = oppsitePallet.GetComponent<uiPallet>();
            pallScript.DestroyPallet();

        }else if(pallet.tag == "RightPellet"){
            Transform oppsitePallet = rightSpawn.GetChild(0);
            uiPallet pallScript = oppsitePallet.GetComponent<uiPallet>();
            pallScript.DestroyPallet();
        }
    }
}
