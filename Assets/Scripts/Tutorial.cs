using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject text;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public GameObject text7;
    public GameObject text8;
    public GameObject text9;
    public GameObject text10;
    public GameObject ui;

    public int textNum = 1;

    void Update(){
        if(textNum <= 11){
            if(Input.GetKeyDown("space")){
                textNum += 1;
            }
        }else{
            SceneManager.LoadScene("MainRoom");
        }
        if(textNum == 1)text.SetActive(true);
        else text.SetActive(false);
        if(textNum == 2)text1.SetActive(true);
        else text1.SetActive(false);
        if(textNum == 3)text2.SetActive(true);
        else text2.SetActive(false);
        if(textNum == 4)text3.SetActive(true);
        else text3.SetActive(false);
        if(textNum == 5){
            text4.SetActive(true);
            ui.SetActive(true);
        }else{
            text4.SetActive(false);
            ui.SetActive(false);
        } 
        if(textNum == 6)text5.SetActive(true);
        else text5.SetActive(false);
        if(textNum == 7)text6.SetActive(true);
        else text6.SetActive(false);
        if(textNum == 8)text7.SetActive(true);
        else text7.SetActive(false);
        if(textNum == 9)text8.SetActive(true);
        else text8.SetActive(false);
        if(textNum == 10)text9.SetActive(true);
        else text9.SetActive(false);
        if(textNum == 11)text10.SetActive(true);
        else text10.SetActive(false);
    }
}
