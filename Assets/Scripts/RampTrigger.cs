using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boat"))
        {
            other.transform.parent.parent.GetComponent<Animator>().SetTrigger("CollidedWithPlatform");
        }
    }
}
