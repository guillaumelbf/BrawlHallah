using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : MonoBehaviour
{
    public float Speed;
    public Light Light;
    public Material Day;
    public Material Night;

    private void Start()
    {
        RenderSettings.skybox = Day;
    }

    private void Update()
    {
        transform.Rotate(Speed, 0, 0);
        Debug.Log(transform.rotation.x);
        if ((transform.rotation.x > 0.70 || transform.rotation.x < -0.70) && Light.intensity > 0)
        {
            Light.intensity -= 0.01f;
            RenderSettings.skybox = Night;
        }
            
        else if ((transform.rotation.x < 0.70 && transform.rotation.x > -0.70) && Light.intensity < 1)
        {
            Light.intensity += 0.01f;
            RenderSettings.skybox = Day;
        }
            
    }
}
