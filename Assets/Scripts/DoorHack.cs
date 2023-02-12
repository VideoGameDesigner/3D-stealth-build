using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHack : MonoBehaviour
{
    public AudioClip doorsound;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag ("Hitenemy"))
        {
            AudioSource.PlayClipAtPoint(doorsound, transform.position);
            Destroy(gameObject,doorsound.length);

        }             
        
    }
}
