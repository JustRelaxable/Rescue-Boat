using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResuceeSitRotationer : MonoBehaviour
{
    private void Awake()
    {
        var xRot = Random.Range(-360, 360);
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.x = xRot;
        transform.localRotation = Quaternion.Euler(rotation);
    }
}
