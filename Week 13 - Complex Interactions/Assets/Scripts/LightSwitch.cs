using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light switchLight;
    public Color colorOn;
    public Color colorOff;

    public void LightOn()
    {
        switchLight.color = colorOn;
    }

    public void LightOff()
    {
        switchLight.color = colorOff;
    }
}
