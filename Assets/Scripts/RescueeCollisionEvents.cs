using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueeCollisionEvents : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boat"))
        {
            print("Kurtarýldýn");
        }
    }
}
