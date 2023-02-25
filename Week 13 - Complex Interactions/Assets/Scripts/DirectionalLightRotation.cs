using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalLightRotation : MonoBehaviour
{
    public Transform directionalLight;
    private HingeJoint hinge;
    private float currentAngle;
    private float previousAngle;
    private Vector3 initialRotation;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        currentAngle = hinge.angle;
        previousAngle = hinge.angle;
        initialRotation = directionalLight.localEulerAngles;
    }

    private void Update()
    {
        currentAngle = hinge.angle;
        if(currentAngle != previousAngle)
        {
            directionalLight.localEulerAngles = new Vector3(Mathf.Floor(initialRotation.x + currentAngle), initialRotation.y, initialRotation.z);
            previousAngle = currentAngle;
        }              
    }
}
