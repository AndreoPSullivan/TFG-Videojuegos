using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Intruso : MonoBehaviour
{

    NavMeshAgent agent;

    [SerializeField]
    Transform target;

    [SerializeField]
    Transform lookAtTarget; 

    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;


    public bool startMoving = false; 
    public float rotationSpeed = 4f;
    private float nextWave = 0;
    private static float timeBetweenWaves = 10;

    private Vector3 scaleChange;


    [SerializeField] GameObject gameController;
    private GameController gameControllerScript;

    // Start is called before the first frame update
    void Start()
    {


        scaleChange = new Vector3(2, 2, 2);
        agent = GetComponent<NavMeshAgent>();

        gameControllerScript = gameController.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startMoving)
        {
            agent.SetDestination(target.position);
            m_animator.SetBool("Grounded", true);

            float dist = Vector3.Distance(target.position, agent.transform.position);

            if (dist <= 6)
            {
                m_animator.SetFloat("MoveSpeed", 0);
                if (gameControllerScript.getCharacter() == 2){
                    RotateTowards();

                }
                
            }
            else
            {
                m_animator.SetFloat("MoveSpeed", 1);
            }



            float distanceCharacter = Vector3.Distance(lookAtTarget.position, agent.transform.position);
            if (distanceCharacter <= 15 && Time.time >= nextWave) {
                m_animator.SetBool("Wave", true);
                nextWave = Time.time + timeBetweenWaves;      


                if (gameControllerScript.getCharacter() == 2){
                    agent.transform.localScale += scaleChange;
                }
            }


        }
    }

    //Rotar hacia la posición del personaje --> Sentir los ojos encima

    private void RotateTowards()
    {
        Vector3 direction = (lookAtTarget.position - agent.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));    // flattens the vector3
        transform.rotation = Quaternion.Slerp(agent.transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
