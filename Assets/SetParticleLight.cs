using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParticleLight : MonoBehaviour
{
    Light particleLight;
    ParticleSystem.MinMaxGradient particleColor;
    ParticleSystem mainParticle;
    ParticleSystem particleDust;

    // Start is called before the first frame update
    void Start()
    {
        particleLight = GetComponentInChildren<Light>();    
        mainParticle = GetComponent<ParticleSystem>();
        particleColor = mainParticle.main.startColor;
        particleDust = transform.GetChild(0).GetComponent<ParticleSystem>();
        ParticleSystem.MainModule ma = particleDust.main;
        SetPartLight();
    }

    public void SetPartLight()
    {
        particleColor = mainParticle.main.startColor;
        SetPartLight(particleColor);
        ParticleSystem.MainModule ma = particleDust.main;
        ma.startColor = particleColor;
    }

    public void SetPartLight(ParticleSystem.MinMaxGradient color)
    {
        ParticleSystem.MainModule ma = particleDust.main;
        ma.startColor = color;
        particleLight.color = color.color;

    }
    public void SetPartLight( float _intensity)
    {
        particleLight.intensity = _intensity;
    }

    public void SetPartLight( float _intensity, float _range)
    {
        particleLight.intensity = _intensity;
        particleLight.range = _range;
    }

    public void SetPartLight(ParticleSystem.MinMaxGradient color, float _intensity)
    {
        ParticleSystem.MainModule ma = particleDust.main;
        ma.startColor = color;
        particleLight.color = color.color;
        particleLight.intensity = _intensity;

    }
    public void SetPartLight(ParticleSystem.MinMaxGradient color, float _intensity, float _range)
    {
        ParticleSystem.MainModule ma = particleDust.main;
        ma.startColor = color;
        particleLight.color = color.color;
        particleLight.intensity = _intensity;
        particleLight.range = _range;

    }
}
