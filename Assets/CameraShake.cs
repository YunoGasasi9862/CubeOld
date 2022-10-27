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
        Vector3 originalpos = transform.localPosition;

        float elapsedTime = 0;

        while(elapsedTime<duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalpos.z);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalpos;
    }
}
