using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{

    [SerializeField] Light Playerlight;
    [SerializeField] GameObject Spot;
    public GameControl mycontroller;

    public GameObject alarmsource;
    
    // Start is called before the first frame update
    void Start()
    {
        alarmsource.SetActive(false);                   
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        RaycastSingle();
    }

    private void RaycastSingle()

    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.TransformDirection(Vector3.forward);

        Ray myRay = new Ray(origin, direction);
        Debug.DrawRay(origin, direction * 5f, Color.blue);

        if (Physics.Raycast(myRay, out RaycastHit myRaycastHit,5f))
        {
            if (myRaycastHit.collider.gameObject.tag == "Player" && Playerlight.enabled == false)
            {
                if (myRaycastHit.collider.gameObject.tag != "Wall" && Playerlight.enabled == false) 
                {
                    Playerlight.enabled = true;
                    GameControl.timeStarted = true;
                    mycontroller.AllClear.enabled = false;
                    mycontroller.timeDisplay.enabled = true;
                    alarmsource.SetActive(true);                    
                                      
                }
                
            }                        
        }
        
    }

    
}