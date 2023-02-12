using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform playertransform;

    private Vector3 _cameraoffset;

    [Range(0.0f, 1.0f)]

    public float smootherfactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _cameraoffset = transform.position - playertransform.position;
    }

    void LateUpdate()
    {
        Vector3 newpos = playertransform.position + _cameraoffset;

        transform.position = Vector3.Slerp(transform.position, newpos, smootherfactor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
