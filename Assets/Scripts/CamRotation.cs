using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour
{

    public float CamAngle;
    public Vector3 Rotationdirection;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotateMe(Rotationdirection * CamAngle, 1f));
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    IEnumerator RotateMe(Vector3 byAngles1, float inTime1)
    {
        while (true)
        {
            var fromAngle1 = transform.rotation;
            var toAngle1 = Quaternion.Euler(transform.eulerAngles + byAngles1);
            for (var t = 0f; t < 1; t += Time.deltaTime / inTime1)
            {
                transform.rotation = Quaternion.Lerp(fromAngle1, toAngle1, t);
                yield return null;
            }
            yield return new WaitForSeconds(1);
            byAngles1 *= -1;
        }

    }

}
