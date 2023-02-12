using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerHack : MonoBehaviour
{
    public GameControl mycontroller;
    bool computeraccessed = true;
    public Material mymaterial;

    // Start is called before the first frame update
    void Start()
    {
        mymaterial.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && computeraccessed == true &&PlayerMovement.Nocomputersound == true)
        {
            mycontroller.minusComputer();
            mymaterial.color = Color.green;
            computeraccessed = false;
            PlayerMovement.Nocomputersound = false;
            

        }
    }

   
}
