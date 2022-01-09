using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatInputController : MonoBehaviour
{
    [SerializeField] private float boatMinYDegree,boatMaxYDegree,boatSpeed,boatRotationSmoothTime,boatRotationSensitivity;
    [SerializeField] Transform humanPivot,boat;
    private float boatYDegree,boatSmoothingVelocity;
    private Quaternion boatInitialRotation;
    private Vector2 initialTouchPosition,deltaBefore;
    public float deltaAcc;


    void Start()
    {
        boatInitialRotation = transform.rotation;
    }
    void Update()
    {
        humanPivot.transform.rotation = Quaternion.Lerp(humanPivot.transform.rotation, boat.transform.rotation, Time.deltaTime*5);
        if (Input.GetMouseButtonDown(0))
        {
            initialTouchPosition = Input.mousePosition;
        }    
        else if (Input.GetMouseButton(0))
        {
            Vector2 touchDelta = (Vector2)Input.mousePosition - initialTouchPosition;
            humanPivot.transform.Rotate(Vector3.up, deltaAcc*Time.deltaTime*5,Space.World);

            float target = touchDelta.x > 0 ? boatMaxYDegree : boatMinYDegree;
            target = target * (Mathf.Abs(touchDelta.x) * boatRotationSensitivity/ Screen.width);
            target = Mathf.Clamp(target, boatMinYDegree, boatMaxYDegree);
            deltaAcc = Mathf.SmoothDamp(deltaAcc, target, ref boatSmoothingVelocity, boatRotationSmoothTime);
            boatYDegree = Mathf.SmoothDamp(boatYDegree, target, ref boatSmoothingVelocity, boatRotationSmoothTime);
            Vector3 boatRotation = new Vector3(boatInitialRotation.x, boatYDegree, boatInitialRotation.z);
            transform.rotation = Quaternion.Euler(boatRotation);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * boatSpeed, Space.Self);
    }
}
