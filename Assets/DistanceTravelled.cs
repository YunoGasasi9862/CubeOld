
using UnityEngine;
using TMPro;

public class DistanceTravelled : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_Distance;

    void Update()
    {

        m_Distance.text = transform.position.z.ToString("0");

    }
}
