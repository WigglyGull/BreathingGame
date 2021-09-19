using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
    public Text timer;
    public float seconds, minutes;
    
    void Update(){
        minutes = (int)(Time.timeSinceLevelLoad/60f);
        seconds = (int)(Time.timeSinceLevelLoad % 60f);
        if(timer != null) timer.text = "Time: " + minutes.ToString("0") + ":" + seconds.ToString("00");
    }
}
