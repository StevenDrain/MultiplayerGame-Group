using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour
{
    [SerializeField] private Light topLight1;
    [SerializeField] private Light topLight2;
     [SerializeField] private Light topLight3;
      [SerializeField] private Light topLight4;
       [SerializeField] private Light topLight5;
   
    [SerializeField] private Light areaLight;

    // Start is called before the first frame update
    void Start()
    {
        topLight1.enabled = false;
        topLight2.enabled = false;
        topLight3.enabled = false;
        topLight4.enabled = false;
        topLight5.enabled = false;
        areaLight.enabled = true; 
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            topLight1.enabled = true; 
            topLight2.enabled = true;
            topLight3.enabled = true;
            topLight4.enabled = true;
            topLight5.enabled = true;
            areaLight.intensity = 1.5f;
            areaLight.range = 15f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            topLight1.enabled = false; // Ensure topLight is turned off
            topLight2.enabled = false;
            topLight3.enabled = false;
            topLight4.enabled = false;
            topLight5.enabled = false;
            areaLight.intensity = 6f;
            areaLight.range = 8f;
        }
    }
}
