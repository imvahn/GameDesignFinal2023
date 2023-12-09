using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;


public class postProcessingChange : MonoBehaviour
{
    
    PostProcessVolume m_Volume;
    Bloom m_Bloom;
    DepthOfField m_DepthoF;
    ChromaticAberration m_ChromaticAberration;
    MotionBlur m_MotionBlur;
    ColorGrading m_ColorGrading;
    Grain m_Grain;
    
    // Start is called before the first frame update
    void Start()
    {
        print("potato");
        turnOnInspiration();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void turnOnInspiration()
    {
        print("potato");
        turnOnBloom();
        turnOnDepth();
        turnOnChromaticAberration();
        turnOnMotionBlur();
        turnOnColorGrading();
        turnOnGrain();
    }
    void turnOnBloom ()
    {
        m_Bloom = ScriptableObject.CreateInstance<Bloom>();
        m_Bloom.enabled.Override(true);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Bloom);
        print("potato1");
        m_Bloom.intensity.Override(30f);
        m_Bloom.softKnee.Override(0.45f);
        m_Bloom.threshold.Override(1f);
        m_Bloom.anamorphicRatio.Override(-0.6f);
        m_Bloom.diffusion.Override(4.97f);
        m_Bloom.fastMode.Override(true);
    }

    void turnOnDepth()
    {
        m_DepthoF = ScriptableObject.CreateInstance<DepthOfField>();
        m_DepthoF.enabled.Override(true);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_DepthoF);

        m_DepthoF.focusDistance.Override(7f);
        m_DepthoF.aperture.Override(11.8f);
        m_DepthoF.focalLength.Override(73f);
        
    }

    void turnOnChromaticAberration()
    {
        m_ChromaticAberration = ScriptableObject.CreateInstance<ChromaticAberration>();
        m_ChromaticAberration.enabled.Override(true);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_ChromaticAberration);

        m_ChromaticAberration.intensity.Override(1f);
    }

    void turnOnMotionBlur()
    {
        m_MotionBlur = ScriptableObject.CreateInstance<MotionBlur>();
        m_MotionBlur.enabled.Override(true);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_MotionBlur);

        m_MotionBlur.shutterAngle.Override(246f);
        m_MotionBlur.sampleCount.Override(10);
    }

    void turnOnColorGrading()
    {
        m_ColorGrading = ScriptableObject.CreateInstance<ColorGrading>();
        m_ColorGrading.enabled.Override(true);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_ColorGrading);

        m_ColorGrading.saturation.Override(50f);
        m_ColorGrading.contrast.Override(50f);
    }

    void turnOnGrain()
    {
        m_Grain = ScriptableObject.CreateInstance<Grain>();
        m_Grain.enabled.Override(true);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Grain);

        m_Grain.colored.Override(true);
        m_Grain.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
        m_Grain.size.value = Mathf.Sin(Time.realtimeSinceStartup);
    }

    void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    }
}
