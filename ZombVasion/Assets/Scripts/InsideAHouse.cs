using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class InsideAHouse : MonoBehaviour
{
    public static bool  insideHouse;

    public Light2D sun;
    public Light2D playerLight;


    private void Update()
    {
        if (insideHouse == true)
        {
            sun.intensity = 0.1f;
            playerLight.enabled = true;
        }
        if (insideHouse == false)
        {
            sun.intensity = 0.35f;
            playerLight.enabled = false;
        }
    }
   
}
