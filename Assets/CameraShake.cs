using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
  public IEnumerator Shake (float duration, float magnitude)
    {

        Vector3 originalpos = transform.localPosition;

        float elapsedtime = 0f;

        while(elapsedtime < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;



            transform.localPosition = new Vector3(x, y, originalpos.z);
            elapsedtime += Time.deltaTime;

            //we want to wait until the next frame
            yield return null;

        }

        //after shaking the camera, set back to the old position
        transform.localPosition = originalpos;

    }
}
