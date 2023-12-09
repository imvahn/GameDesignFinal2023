using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;



public class postProcessingEnable : MonoBehaviour
{

    public static postProcessingEnable instance;

    PostProcessVolume m_Volume;
    Bloom m_Bloom;
    DepthOfField m_DepthoF;
    ChromaticAberration m_ChromaticAberration;
    MotionBlur m_MotionBlur;
    ColorGrading m_ColorGrading;
    Grain m_Grain;

    bool spooky = false;
    float temp;
    float tint;
    float amplitude = 100;

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    public void Update()
    {
        if (spooky)
        {
            tint = Mathf.Cos(Time.time) * amplitude;
            temp = Mathf.Sin(Time.time) * amplitude;
            m_ColorGrading.tint.Override(tint);
            m_ColorGrading.temperature.Override(temp);
            //print("temp: " + temp);\
            //print("tint: " + tint);
        }
    }
    public void TurnOnInspiration()
    {
        turnOnBloom();
        turnOnDepth();
        turnOnChromaticAberration();
        turnOnMotionBlur();
        turnOnColorGrading();
        turnOnGrain();
    }
    public void turnOnBloom()
    {
        
        m_Bloom = ScriptableObject.CreateInstance<Bloom>();
        m_Bloom.enabled.Override(true);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Bloom);

        m_Bloom.intensity.Override(30f);
        m_Bloom.softKnee.Override(0.45f);
        m_Bloom.threshold.Override(1f);
        m_Bloom.anamorphicRatio.Override(-0.6f);
        m_Bloom.diffusion.Override(4.97f);
        m_Bloom.fastMode.Override(true);
    }

    public void turnOnDepth()
    {
        m_DepthoF = ScriptableObject.CreateInstance<DepthOfField>();
        m_DepthoF.enabled.Override(true);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_DepthoF);

        m_DepthoF.focusDistance.Override(7f);
        m_DepthoF.aperture.Override(11.8f);
        m_DepthoF.focalLength.Override(73f);

    }

    public void turnOnChromaticAberration()
    {
        m_ChromaticAberration = ScriptableObject.CreateInstance<ChromaticAberration>();
        m_ChromaticAberration.enabled.Override(true);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_ChromaticAberration);

        m_ChromaticAberration.intensity.Override(1f);
    }

    public void turnOnMotionBlur()
    {
        m_MotionBlur = ScriptableObject.CreateInstance<MotionBlur>();
        m_MotionBlur.enabled.Override(true);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_MotionBlur);

        m_MotionBlur.shutterAngle.Override(246f);
        m_MotionBlur.sampleCount.Override(10);
    }

    public void turnOnColorGrading()
    {
        m_ColorGrading = ScriptableObject.CreateInstance<ColorGrading>();
        m_ColorGrading.enabled.Override(true);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_ColorGrading);
        m_ColorGrading.saturation.Override(50f);
        m_ColorGrading.contrast.Override(50f);
        spooky = true;
    }

    public void turnOnGrain()
    {
        m_Grain = ScriptableObject.CreateInstance<Grain>();
        m_Grain.enabled.Override(true);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Grain);

        m_Grain.colored.Override(true);
        // static val not compared to time for ~randomness~
        m_Grain.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
        m_Grain.size.value = Mathf.Sin(Time.realtimeSinceStartup);
    }

    public void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    }
}

