using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hacking : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject bullet;
    public float bulletspeed = 6f;
    Rigidbody rb;
    public GameControl mycontroller;
    bool shooting = true;
    public AudioClip Firingsound;
    private AudioSource myaudio;
    private float firerate = 0.4f;
    private float Nextfire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        bullet.SetActive(true);
        rb = GetComponent<Rigidbody>();
        myaudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))

        {
            if(shooting == true)
            {
              mycontroller.minusHack();
              shoothackbullet();
              myaudio.PlayOneShot(Firingsound);
            }
            
        }
        
        if(GameControl.hacksleft == false)

        {
            bullet.SetActive(false);
            shooting = false;
        }

        if (GameControl.hacksleft == true && shooting == false)

        {
            bullet.SetActive(true);
            shooting = true;

        }
       
    }

    private void shoothackbullet()

    {
        GameObject cb = Instantiate(bullet, spawnpoint.position, bullet.transform.rotation);
        rb = cb.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletspeed;
        
    }

    public void Fire(InputAction.CallbackContext context)
    {
       if(shooting == true && Time.time > Nextfire)
        {
            mycontroller.minusHack();
            Nextfire = Time.time + firerate;
            shoothackbullet();
            myaudio.PlayOneShot(Firingsound);

        }
     


    }

}
