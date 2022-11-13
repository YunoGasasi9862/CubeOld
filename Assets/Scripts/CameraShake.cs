using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] GameManager gamemanager;

    private void Update()
    {
        if(gamemanager.isOver)
        {
            Time.timeScale = 0;
        }
    }
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float ElapsedTime = 0f;

        while(ElapsedTime<duration)
        {
            float X = Random.Range(-1f, 1f) * magnitude;

            float Y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(X, Y, originalPos.z);

            ElapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;


    }
}
