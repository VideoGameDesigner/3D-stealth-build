using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    [SerializeField] Light Playerlight;
    [SerializeField] GameObject Help;
    public GameControl mycontroller;
    public GameObject alarmsource;
    
   

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
        if(other.gameObject.CompareTag("Player"))
        {
            
            Playerlight.enabled = false;
            GameControl.timeStarted = false;
            mycontroller.AllClear.enabled = true;
            mycontroller.timeDisplay.enabled = false;
            alarmsource.SetActive(false);
            
           
        }
            
    }

    


}
