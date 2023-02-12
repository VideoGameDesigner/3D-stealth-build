using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetect : MonoBehaviour
{
    [SerializeField] Light Playerlight;
    [SerializeField] GameObject Spot;
    public GameControl mycontroller;
    public float sphereradius;
    public float raydistance;
    public LayerMask layermask;

    private Vector3 origin;
    private Vector3 direction;

    public GameObject alarmsource;

    // Start is called before the first frame update
    void Start()
    {
        Playerlight.enabled = false;
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
        origin = transform.position;
        direction = transform.forward;

        if (Physics.SphereCast(origin,sphereradius,direction, out RaycastHit myRaycastHit, raydistance,layermask))
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Debug.DrawRay(origin, direction * raydistance, Color.blue);
        Gizmos.DrawWireSphere(origin + direction * raydistance, sphereradius);
    }
}
