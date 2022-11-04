using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollidewithBoundary : MonoBehaviour
{
    [SerializeField] LevelGenerator generator;
    [SerializeField] TextMeshProUGUI Warning;
    private TextMeshProUGUI warning;
    private bool triggerwaring = false;
    private float elapsedTime = 0f;
    float DistanceZ = 22;

    private void Start()
    {
        warning=GameObject.Find("/HUD/Warning").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if(triggerwaring)
        {
            warning.enabled = true;
            elapsedTime += Time.deltaTime;
        }

        if(elapsedTime>2f)
        {
            triggerwaring = false;
            elapsedTime = 0f;
            warning.enabled = false;
        }
    }

    private void Awake()
    {
        generator = FindObjectOfType<LevelGenerator>().GetComponent<LevelGenerator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(transform.parent.gameObject, 3f); //destroy the parent of the gameobject
            triggerwaring = true;
            //after that platform is destroyed
            Instantiate(generator.plat, generator.pos, generator.plat.transform.rotation);
            generator.pos.z += DistanceZ;

        }
    }
}
