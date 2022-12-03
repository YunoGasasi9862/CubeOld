using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackSpeed : MonoBehaviour
{
    private ParticleSystem pa;
    public ParticleSystem[] psChildren;
    void Start()
    {
        pa = GetComponent<ParticleSystem>(); //parent
        psChildren=pa.GetComponentsInChildren<ParticleSystem>();//only storing the particle systems of the children
    }

    private void Update()
    {
        foreach(ParticleSystem ps in psChildren)
        {
            var SpeedMain = ps.main;  //new way to update the simulation speed
            SpeedMain.simulationSpeed = 2f;
        }
      

    }
}
