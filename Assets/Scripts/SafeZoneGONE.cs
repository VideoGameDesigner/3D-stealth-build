using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneGONE : MonoBehaviour
{
    public Material SafezoneMaterial;
    int Lifeline = 2; 
    // Start is called before the first frame update
    void Start()
    {
        SafezoneMaterial.color = Color.green;
    }


    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.CompareTag("Player"))
        {
            SafezoneMaterial.color = Color.red;
            Lifeline--;
        }

        if (other.gameObject.CompareTag("Player") && Lifeline == 1)
        {
            SafezoneMaterial.color = Color.cyan;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Lifeline == 0)
        {
            Destroy(gameObject, 3f);
        }
    }

}

