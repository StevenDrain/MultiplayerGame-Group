using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour
{
    [SerializeField] private Light topLight;
    [SerializeField] private Light areaLight;

    // Start is called before the first frame update
    void Start()
    {
        topLight.enabled = false;
        areaLight.enabled = true; 
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            topLight.enabled = !topLight.enabled; // Ensure topLight is turned on
            areaLight.intensity = 1.5f;
            areaLight.range = 15f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            topLight.enabled = !topLight.enabled; // Ensure topLight is turned off
            areaLight.intensity = 6f;
            areaLight.range = 8f;
        }
    }
}
