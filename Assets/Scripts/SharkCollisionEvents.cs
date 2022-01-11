using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkCollisionEvents : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boat"))
        {
            other.GetComponent<Animator>().SetTrigger("CollidedWithIsland");
        }
    }
}
