
using UnityEngine;
using TMPro;

public class DistanceTravelled : MonoBehaviour
{
    private TextMeshProUGUI m_Distance;

    private void Start()
    {
        m_Distance = GameObject.Find("/HUD/DistanceNumber").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(transform.position.z >=0)
        {
            m_Distance.text = transform.position.z.ToString("0");

        }else
        {
            m_Distance.text = 0.ToString("0");
        }

    }
}
