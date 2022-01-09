using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatHumanPivotMovement : MonoBehaviour
{
    [SerializeField] private Transform humanPivot, boat;
    [SerializeField] private float humanPivotRoationTime,humanPivotBackSensitivity,humanPivotAccelarationSensitivity;
    private float deltaAcceleration,humanPivotSmoothingVelocity;
    private BoatMovement boatMovement;
    private BoatInput boatInput;

    private void Awake()
    {
        boatMovement = GetComponent<BoatMovement>();
        boatInput = GetComponent<BoatInput>();
    }

    private void Update()
    {
        humanPivot.transform.rotation = Quaternion.Lerp(humanPivot.transform.rotation, boat.transform.rotation, Time.deltaTime * humanPivotBackSensitivity);
        var inputInfo = boatInput.GetInputInfo();
        if (inputInfo.isDragging)
        {
            humanPivot.transform.Rotate(Vector3.up, deltaAcceleration * Time.deltaTime * humanPivotAccelarationSensitivity,Space.World);
            deltaAcceleration = Mathf.SmoothDamp(deltaAcceleration, boatMovement.GetTargetAngle(), ref humanPivotSmoothingVelocity, humanPivotRoationTime);
        }
    }
}
