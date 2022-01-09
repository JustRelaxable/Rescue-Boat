using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatInput : MonoBehaviour
{
    private Vector2 touchDelta;
    private Vector2 initialTouchPosition;
    private bool isDragging = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialTouchPosition = Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButton(0))
        {
            touchDelta = (Vector2)Input.mousePosition - initialTouchPosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    public InputInfo GetInputInfo()
    {
        return new InputInfo() { isDragging = this.isDragging, touchDelta = this.touchDelta };
    }
}

public struct InputInfo
{
    public Vector2 touchDelta;
    public bool isDragging;
}
