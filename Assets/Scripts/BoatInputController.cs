using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatInputController : MonoBehaviour
{
    [SerializeField] private float boatMinYDegree,boatMaxYDegree,boatRotateSensitivity,boatSpeed,boatRotationSmoothTime;
    private float boatYDegree,boatSmoothingVelocity;
    private Quaternion boatInitialRotation;
    private Vector2 initialTouchPosition;



    void Start()
    {
        boatInitialRotation = transform.rotation;
    }
    void Update()
    {    
        if (Input.GetMouseButtonDown(0))
        {
            initialTouchPosition = Input.mousePosition;
        }    
        else if (Input.GetMouseButton(0))
        {
            Vector2 touchDelta = (Vector2)Input.mousePosition - initialTouchPosition;
            //touchDelta.x = Mathf.Clamp(touchDelta.x, -1, 1);
            float target = touchDelta.x > 0 ? boatMaxYDegree : boatMinYDegree;
            //boatYDegree += touchDelta.x * Time.deltaTime * boatRotateSensitivity;
            //boatYDegree = Mathf.Clamp(boatYDegree, boatMinYDegree, boatMaxYDegree);
            boatYDegree = Mathf.SmoothDamp(boatYDegree, target, ref boatSmoothingVelocity, boatRotationSmoothTime);
            Vector3 boatRotation = new Vector3(boatInitialRotation.x, boatYDegree, boatInitialRotation.z);
            transform.rotation = Quaternion.Euler(boatRotation);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * boatSpeed, Space.Self);
    }
}
