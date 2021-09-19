using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui : MonoBehaviour{
    public GameObject buttonPrompt;
    public GameObject leftPallet;
    public GameObject rightPallet;

    public Transform leftSpawn;
    public Transform rightSpawn;

    public string button = "e";

    public Sprite E;
    public Sprite Q;

    public int life;
    public float speed;
    public GameObject manager;
    GameManager gm;

    public float startPalletTimer = 1.5f;
    float palletTimer;

    SpriteRenderer spButton;

    void Start(){
        life = 0;
        palletTimer = startPalletTimer;
        spButton = buttonPrompt.GetComponent<SpriteRenderer>();

        gm = manager.GetComponent<GameManager>();
    }

    void Update(){
        Debug.Log(life);
        if(life >= 10){
            SceneManager.LoadScene("MainRoom");
        }
        if(gm.minutes >= 1 && startPalletTimer != 1){
            startPalletTimer = 1;
        }
        if(gm.minutes >= 2 && startPalletTimer != 0.5f){
            startPalletTimer = 0.5f;
        }
        
        
        if(palletTimer <= 0){
            palletTimer = startPalletTimer;
            spawnPallets();
        }else palletTimer -= 1 * Time.deltaTime;
    }

    void spawnPallets(){
        GameObject newLeftPallet = leftPallet;
        GameObject newRightPallet = rightPallet;

        uiPallet leftUiPallet = newLeftPallet.GetComponent<uiPallet>();
        uiPallet rightUiPallet = newRightPallet.GetComponent<uiPallet>();

        if(life >= 4){
            leftUiPallet.startSpeed = 1;
            rightUiPallet.startSpeed = 1;
            startPalletTimer = 1;
        }else if(life >= 8){
            leftUiPallet.startSpeed = 1.5f;
            rightUiPallet.startSpeed = 1.5f;
            startPalletTimer = 0.5f;
        }

        Instantiate(newLeftPallet, rightSpawn);
        Instantiate(newRightPallet, leftSpawn);
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
