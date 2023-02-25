using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessRuntimeEffects : MonoBehaviour
{
    public Volume vol;
    public SliderPercentage bloomSlider;
    public SliderPercentage chromaticAberrationSlider;
    public SliderPercentage lensDistortionSlider;
    public SliderPercentage redSlider;
    public SliderPercentage greenSlider;
    public SliderPercentage blueSlider;

    public Vector2 bloomRange;
    public Vector2 chromaticAberrationRange;
    public Vector2 lensDistortionRange;
    public Vector2 colorRange;  

    private float bloomValue;
    private float chromaticAberrationValue;
    private float lensDistortionValue;
    private float redValue;
    private float greenValue;
    private float blueValue;

    Bloom bloom;
    ChromaticAberration chromaticAberration;
    LensDistortion lensDistortion;
    ColorAdjustments colorAdjustment;

    void Start()
    {
        vol.profile.TryGet<Bloom>(out bloom);
        vol.profile.TryGet<ChromaticAberration>(out chromaticAberration);
        vol.profile.TryGet<LensDistortion>(out lensDistortion);
        vol.profile.TryGet<ColorAdjustments>(out colorAdjustment);

        bloomValue = bloom.intensity.value;
        chromaticAberrationValue = chromaticAberration.intensity.value;
        lensDistortionValue = lensDistortion.intensity.value;
        redValue = colorAdjustment.colorFilter.value.r;
        greenValue = colorAdjustment.colorFilter.value.g;
        blueValue = colorAdjustment.colorFilter.value.b;

        bloomSlider.OnVariableChange += SetBloom;
        chromaticAberrationSlider.OnVariableChange += SetChromaticAberration;
        lensDistortionSlider.OnVariableChange += SetLensDistortion;
        redSlider.OnVariableChange += SetRed;
        greenSlider.OnVariableChange += SetGreen;
        blueSlider.OnVariableChange += SetBlue;
    }

    private float adjustRange(float pecentage, Vector2 range)
    {
        return range.x + ((range.y - range.x) * pecentage);
    }


    private void SetBloom(float newVal)
    {
        bloom.intensity.value = adjustRange(newVal, bloomRange);
    }

    private void SetChromaticAberration(float newVal)
    {
        chromaticAberration.intensity.value = adjustRange(newVal, chromaticAberrationRange);
    }

    private void SetLensDistortion(float newVal)
    {
        lensDistortion.intensity.value = adjustRange(newVal, lensDistortionRange);
    }

    private void SetRed(float newVal)
    {
        Color newColor = new Color(adjustRange(newVal, colorRange), colorAdjustment.colorFilter.value.g, colorAdjustment.colorFilter.value.b);
        colorAdjustment.colorFilter.Override(newColor);
    }

    private void SetGreen(float newVal)
    {
        Color newColor = new Color(colorAdjustment.colorFilter.value.r, adjustRange(newVal, colorRange), colorAdjustment.colorFilter.value.b);
        colorAdjustment.colorFilter.Override(newColor);
        
    }

    private void SetBlue(float newVal)
    {
        Color newColor = new Color(colorAdjustment.colorFilter.value.r, colorAdjustment.colorFilter.value.g, adjustRange(newVal, colorRange));
        colorAdjustment.colorFilter.Override(newColor);
    }


    /*
    void PostProcessValueChange()
    {
        bloom.intensity.value = bloomSlider.value;
        chromaticAberration.intensity.value = chromaticAberrationSlider.value;
        lensDistortion.intensity.value = lensDistortionSlider.value;
        Color newColor = new Color(redSlider.value, greenSlider.value, blueSlider.value);
        colorAdjustment.colorFilter.Override(newColor);
    }

    public void ResetSettings()
    {
        bloomSlider.value = 0;
        chromaticAberrationSlider.value = 0;
        lensDistortionSlider.value = 0;
        redSlider.value = 1;
        greenSlider.value = 1;
        blueSlider.value = 1;
    }
    */
}
