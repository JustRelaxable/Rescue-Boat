using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampTrigger : MonoBehaviour
{
    bool animationPlayed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boat") && !animationPlayed)
        {
            other.GetComponent<Animator>().SetTrigger("CollidedWithPlatform");
            animationPlayed = true;
        }
    }
}
