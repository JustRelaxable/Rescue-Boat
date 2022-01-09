using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    [SerializeField] private float boatMinYDegree, boatMaxYDegree, boatSpeed, boatRotationSmoothTime, boatRotationSensitivity;
    private float boatYDegree, boatSmoothingVelocity,target;
    private BoatInput boatInput;
    private Quaternion boatInitialRotation;
    private Rigidbody rigidbody;


    private void Awake()
    {
        boatInput = GetComponent<BoatInput>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        boatInitialRotation = transform.rotation;
    }

    private void Update()
    {
        var inputInfo = boatInput.GetInputInfo();
        //transform.Translate(Vector3.forward * Time.deltaTime * boatSpeed, Space.Self);
        
        if (inputInfo.isDragging)
        {
            target = inputInfo.touchDelta.x > 0 ? boatMaxYDegree : boatMinYDegree;
            target = target * (Mathf.Abs(inputInfo.touchDelta.x) * boatRotationSensitivity / Screen.width);
            target = Mathf.Clamp(target, boatMinYDegree, boatMaxYDegree);
            boatYDegree = Mathf.SmoothDamp(boatYDegree, target, ref boatSmoothingVelocity, boatRotationSmoothTime);
            Vector3 boatRotation = new Vector3(boatInitialRotation.x, boatYDegree, boatInitialRotation.z);
            transform.rotation = Quaternion.Euler(boatRotation);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = (transform.forward* boatSpeed);
    }

    public float GetTargetAngle()
    {
        return target;
    }
}
