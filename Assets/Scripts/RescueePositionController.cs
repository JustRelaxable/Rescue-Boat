using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescueePositionController : MonoBehaviour
{
    [SerializeField] Transform[] rescueeSit;
    private int sitIndex = 0;
    public void SaveRescuee(GameObject rescuee)
    {
        if (sitIndex >= rescueeSit.Length)
            return;
        rescuee.transform.localScale = new Vector3(1, 1, 1);
        rescuee.transform.position = rescueeSit[sitIndex].position;
        rescuee.transform.rotation = rescueeSit[sitIndex].rotation;
        rescuee.transform.parent = rescueeSit[sitIndex].transform;
        sitIndex++;
    }
}
