using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackAmmo : MonoBehaviour
{

    public GameControl mycontroller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mycontroller.extraHack();
            Destroy(gameObject);
        }
    }

}
