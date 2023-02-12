using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public AudioClip Hackammosound;
    public AudioClip Bonusdiscsound;
    public AudioClip Computersound;
    public AudioClip oksound;
    private AudioSource myaudio;
    private Vector3 movement;
    public static bool Nocomputersound = false;



    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myaudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    private void FixedUpdate()
    {
        playerMovement();
    }

    void playerMovement()

    {
        float Hmov = Input.GetAxis("Horizontal");
        float Vmov = Input.GetAxis("Vertical");

        movement = new Vector3(Hmov, 0, Vmov);

        if (movement == Vector3.zero)

        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(movement);
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * Time.fixedDeltaTime);

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        rb.MoveRotation(targetRotation);
        
    }

    private void LateUpdate()
    {
        if (transform.position.y <= -15)
        {
            transform.position = new Vector3(0, 1, 0);
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ammo"))
        {
            myaudio.PlayOneShot(Hackammosound);
        }

        if(other.gameObject.CompareTag("Bonus"))
        {
            myaudio.PlayOneShot(Bonusdiscsound);
        }

        if(other.gameObject.CompareTag("Safe"))
        {
            myaudio.PlayOneShot(oksound);

        }

                                
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Computer")&& !Nocomputersound)
        {
            myaudio.PlayOneShot(Computersound);
            Nocomputersound = true;
            
        }
     
                
    }

   





    public void Move(InputAction.CallbackContext context)
    {
        Vector3 value = context.ReadValue<Vector2>();
        movement = new Vector3(value.x, 0, value.z);

    }
    
}
