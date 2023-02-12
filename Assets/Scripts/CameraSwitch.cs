using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    
    public CameraDetect TurnOFF;
    private Light CamLight;


    // Start is called before the first frame update
    void Start()
    {
        TurnOFF.enabled = true;
        CamLight = GetComponent<Light>();
        CamLight.enabled = true;        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CAMOFF());
    }

    IEnumerator CAMOFF()

    {
        if (TurnOFF.enabled == true && CamLight.enabled == true)

        {
            yield return new WaitForSeconds(6f);
            TurnOFF.enabled = false;
            CamLight.enabled = false;
        }

        if (TurnOFF.enabled == false && CamLight.enabled == false)

        {
            yield return new WaitForSeconds(6f);
            TurnOFF.enabled = true;
            CamLight.enabled = true;
        }
    }
}
