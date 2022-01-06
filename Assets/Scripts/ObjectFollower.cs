using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] GameObject target;
    Vector3 difference;
    void Start()
    {
        difference = transform.position - target.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = target.transform.position + difference;
    }
}
