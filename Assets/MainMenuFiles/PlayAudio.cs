using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public GameObject audioObj;
    public void pAudio()
    {
        Instantiate(audioObj, transform.position, Quaternion.identity);
    }
}
