using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishIslandCollisionEvent : MonoBehaviour
{
    [SerializeField] Transform[] dansadam;
    [SerializeField] GameObject dansAdam;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boat"))
        {
            other.GetComponent<Animator>().SetTrigger("CollidedWithFinish");
            other.GetComponent<BoatInputController>().enabled = false;
            other.GetComponent<BoatInputController>().DisableSplat();
            other.GetComponent<RescueePositionController>().HideHoomans();
            DsansADmalr();
            FindObjectOfType<Cinemachine.CinemachineVirtualCamera>().LookAt = dansadam[0];
        }
    }

    private void DsansADmalr()
    {
        foreach (var item in dansadam)
        {
            Instantiate(dansAdam, item.transform.position,item.rotation);
        }
    }
}
