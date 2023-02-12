using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    [SerializeField] float rotateSpeed;
    public LookAround enemyfreeze;
    bool turnstopped = true;
    public Light EnemyLight;
    public float enemyspeed;
    public AudioClip enemystunsound;
    private AudioSource myaudio;

    // Start is called before the first frame update
    void Start()
    {       
        agent = GetComponent<NavMeshAgent>();
        GotoNextPoint();
        agent.speed = enemyspeed;
        agent.isStopped = false;
        enemyfreeze.enabled = true;
        EnemyLight.enabled = true;
        myaudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {           
            agent.speed = 0f; 
            StartCoroutine(stop());
            GotoNextPoint();
        }

        if(agent.speed == 0f && turnstopped == true)

        {
            turning();
        }
    }

    

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
        {
            return;
        }
        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
       
    }

    private void OnCollisionEnter(Collision collision)
    {
              
        if (agent.isStopped == false && collision.gameObject.CompareTag("Hitenemy") && turnstopped == true)

        {
            turnstopped = false;
            agent.isStopped = true;
            enemyfreeze.enabled = false;
            EnemyLight.enabled = false;
        }

       if (agent.isStopped == true && enemyfreeze.enabled == false && turnstopped == false)

        {
            agent.speed = 0;
            myaudio.PlayOneShot(enemystunsound);
        }


        StartCoroutine(resume());
    }



    void turning()
    {
        transform.Rotate(new Vector3(0f, rotateSpeed, 0f) * Time.deltaTime);
    }

    IEnumerator stop()

    {
        if(agent.speed == 0)

        {           
            yield return new WaitForSeconds(3f);
            agent.speed = enemyspeed;
        }

    }

    IEnumerator resume()

    {
        if(agent.speed == 0 && agent.isStopped == true && enemyfreeze.enabled == false && turnstopped == false && EnemyLight.enabled == false)

        {
            yield return new WaitForSeconds(6f);
            agent.speed = enemyspeed;
            agent.isStopped = false;
            enemyfreeze.enabled = true;
            turnstopped = true;
            EnemyLight.enabled = true;
        }

    }
}
