using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugStick : MonoBehaviour
{
    public Material onTriggerEnterMat;
    public Material onTriggerExitMat;
    public TextMeshProUGUI text;

    private Renderer ren;

    private void Start()
    {
        //text = GetComponent<TextMeshProUGUI>();
        ren = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ren.material = onTriggerEnterMat;
        text.SetText(other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        ren.material = onTriggerExitMat;
    }
}
