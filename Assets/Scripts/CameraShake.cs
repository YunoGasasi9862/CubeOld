using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] GameManager gamemanager;

    private void Update()
    {
        if(gamemanager.isOver)  //stop shaking it!
        {
            Time.timeScale = 0;
        }
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapsedTime = 0f;
        
        while(elapsedTime<duration)
        {
            float X = Random.Range(-1f, 1f) * magnitude;

            float Y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(X, Y, originalPos.z);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;

    }

}
