using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescueePositionController : MonoBehaviour
{
    [SerializeField] Slider progressSlider;
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
        progressSlider.value += 1;
        sitIndex++;
    }

    public void HideHoomans()
    {
        foreach (var item in rescueeSit)
        {
            item.gameObject.SetActive(false);
        }
    }
}
