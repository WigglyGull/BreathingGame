using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_shake : MonoBehaviour{
    public Transform player;

    public void StartShake(){
        StartCoroutine(Shake());
    }

    public IEnumerator Shake(){
        Vector3 originalPosition = new Vector3(player.position.x, 0, -10);
        float elapsedTime = 0f;
        float duration = 0.2f;
        float magnitude = 0.2f;
        float range = 0.2f;

        if (player.position.x < -3.93) originalPosition = new Vector3(-3.93f, 0, -10);
        if(player.position.x > 3.93) originalPosition = new Vector3(3.93f, 0, -10);

        while (elapsedTime < duration){
            originalPosition = new Vector3(player.position.x, 0, -10);
            if (player.position.x < -3.93) originalPosition = new Vector3(-3.93f, 0, -10);
            if(player.position.x > 3.93) originalPosition = new Vector3(3.93f, 0, -10);

            float xOffset = Random.Range(-range, range) * magnitude;
            float yOffset = Random.Range(-range, range) * magnitude;

            transform.localPosition = new Vector3(originalPosition.x + xOffset, yOffset, originalPosition.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPosition;
    }
}
