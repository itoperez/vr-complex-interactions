using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    private List<InputDevice> devices;
    private InputDevice targetDevice;

    private Animator handAnimator;


    void Start()
    {
        TryInitialize();
    }

    private void Update()
    {
        if (!targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            UpdateHandAnimation();
        }        
    }

    private void TryInitialize()
    {
        devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        /*
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
        */

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            handAnimator = GetComponent<Animator>();
        }

    } // Try to Initialize Controllers

    private void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }

    } // Update Hand Animation    
}
