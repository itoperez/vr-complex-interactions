using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPercentage : MonoBehaviour
{
    public Transform startPosition;
    public Transform maxPosition;
    public Transform minPosition;
    private float percentage = 0;

    private static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
    {
        Vector3 AB = b - a;
        Vector3 AV = value - a;
        return Mathf.Clamp01(Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB));
    }

    private void Start()
    {
        transform.position = startPosition.position;
    }

    private void Update()
    {
        Percentage = InverseLerp(minPosition.position, maxPosition.position, transform.position);
    }


    public delegate void OnVariableChangeDelegate(float newVal);
    public event OnVariableChangeDelegate OnVariableChange;

    public float Percentage
    {
        get {return percentage;}
        set
        {
            if (percentage == value) return;
            percentage = value;
            if (OnVariableChange != null)
            {
                OnVariableChange(percentage);
            }                
        }
    }    
}
