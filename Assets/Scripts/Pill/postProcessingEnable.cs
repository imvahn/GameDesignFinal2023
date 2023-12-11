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
    AmbientOcclusion m_ambient;
    LensDistortion m_lensDistortion;

    bool spooky = false;
    float T;
    float temp;
    float tint;
    float grain;
    float ambient;
    float ambientAmplitude;
    float amplitude = 100;
    float grainII;
    float grainIS;


    float lensIntensity = 2;
    float lensX;
    float lensY;
    float lensIntensityAmplitude = 50; // 0 - 50 slow


    // Start is called before the first frame update
    void Start()
    {

        TurnOnInspiration();

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
    void Update()
    {
        if (spooky)
        {


            tint = Mathf.Cos(Time.time) * amplitude;
            temp = Mathf.Sin(Time.time) * amplitude;
            m_ColorGrading.tint.Override(tint);
            m_ColorGrading.temperature.Override(temp);
            //print("temp: " + temp);

            T = Time.time;
            tint = Mathf.Cos(2.5f * T) * amplitude;
            temp = Mathf.Sin(2.5f * T) * amplitude;

            m_ColorGrading.tint.Override(tint);
            m_ColorGrading.temperature.Override(temp);

            ambient = Mathf.Abs(Mathf.Cos(T) * ambientAmplitude) / 2f;
            m_ambient.intensity.Override(ambient);


            grainII = Mathf.Abs(Mathf.Cos(T) / 2f) + 0.5f;
            grainIS = Mathf.Abs(Mathf.Sin(T) * 1.2f) + .8f;

            m_Grain.intensity.Override(grainII);
            m_Grain.size.Override(grainIS);

            lensIntensity = Mathf.Abs(Mathf.Cos(T)) * lensIntensityAmplitude;
            //print(lensIntensity);
            //lensX = Mathf.Abs(Mathf.Sin(T));
            //lensY = Mathf.Abs(Mathf.Cos(T));
            //print("int: " + lensIntens    ity + ", X: " + lensX + ", Y :" + lensY);

            m_lensDistortion.intensity.Override(lensIntensity);
            //m_lensDistortion.centerX.Override(lensX);
            //m_lensDistortion.centerY.Override(lensY);
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
        turnOnAmbientOcc();
        turnOnLensDistortion();
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
        spooky = true;
    }

    void turnOnGrain()
    {
        m_Grain = ScriptableObject.CreateInstance<Grain>();
        m_Grain.enabled.Override(true);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Grain);

        //m_Grain.colored.Override(true);

    }

    public void turnOnAmbientOcc()
    {
        m_ambient = ScriptableObject.CreateInstance<AmbientOcclusion>();
        m_ambient.enabled.Override(true);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_ambient);
    }

    public void turnOnLensDistortion()
    {
        m_lensDistortion = ScriptableObject.CreateInstance<LensDistortion>();
        m_lensDistortion.enabled.Override(true);
        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_lensDistortion);
    }

    //void OnDestroy()
    //{
    //    RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    //}
}

