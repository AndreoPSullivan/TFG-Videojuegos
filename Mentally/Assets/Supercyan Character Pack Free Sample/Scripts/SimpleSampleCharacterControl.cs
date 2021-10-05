using System.Collections.Generic;
using UnityEngine;
using TMPro;


[ExecuteInEditMode]
public class SimpleSampleCharacterControl : MonoBehaviour
{
   

    LanguageManager languageManager = new LanguageManager();
    private float m_moveSpeed = 20;

    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;


    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 50;
    private readonly float m_walkScale = 0.5f;

    private bool m_wasGrounded;
    private Vector3 m_currentDirection = Vector3.zero;

    /*
    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;
    private bool m_jumpInput = false;
    */
    private bool m_isGrounded;

    private List<Collider> m_collisions = new List<Collider>();

    private bool inBed = false;
    private Transform bedPosition;
    int bucleWakeup = 0;

    [SerializeField] private GameObject gameController;
    private GameController gameControllerScript;
    public TextMeshProUGUI textCharacter;
    [SerializeField] GameObject texto;

    public Material[] TCA;
    public Material[] TAS;
    public Material[] DEP;


    float randomMessage = 9999999999999999;
    float timeBetweenMessages = 10;

    private static int minMessage = 0;
    private static int maxMessage = 4;

    private float lastNote = 0.0f;

    SkinnedMeshRenderer player;
    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
        player = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();

    }


    private void Start()
    {
        randomMessage = Time.time + timeBetweenMessages;
        gameControllerScript = gameController.GetComponent<GameController>();

    }

    public void onEnable()
    {

        switch (gameControllerScript.getCharacter())
        {
            //TCA
            case 1:
                player.materials = TCA;
                break;
            //TAS
            case 2:
                player.materials = TAS;
                break;
            //Depression
            case 3:
                player.materials = DEP;
                m_moveSpeed = 10;
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                if (!m_collisions.Contains(collision.collider))
                {
                    m_collisions.Add(collision.collider);
                }
                m_isGrounded = true;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            m_currentV = 0;
            m_currentH = 0;
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.Space) && inBed)
        {
            while (bucleWakeup < 10)
            {
                bucleWakeup++;
                WakeUp();

            }
            bucleWakeup = 0;

        }

        if (Time.time >= randomMessage && !gameControllerScript.getPaused())
        {
            randomMessage = Time.time + timeBetweenMessages;
            textCharacter.text = languageManager.getText(gameControllerScript.getLanguage() * 4 + gameControllerScript.getCharacter(), Random.Range(minMessage, maxMessage));
            texto.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        m_animator.SetBool("Grounded", m_isGrounded);


        DirectUpdate();
      
        m_wasGrounded = m_isGrounded;
        //m_jumpInput = false;
    }


    private void DirectUpdate()
    {

        if (!inBed)
        {

            float v = Input.GetAxis("Vertical");
            float h = Input.GetAxis("Horizontal");

            Transform camera = Camera.main.transform;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                v *= m_walkScale;
                h *= m_walkScale;
            }

            m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
            m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);

            Vector3 direction = camera.forward * m_currentV + camera.right * m_currentH;

            float directionLength = direction.magnitude;
            direction.y = 0;
            direction = direction.normalized * directionLength;

            if (direction != Vector3.zero)
            {
                m_currentDirection = Vector3.Slerp(m_currentDirection, direction, Time.deltaTime * m_interpolation);

                transform.rotation = Quaternion.LookRotation(m_currentDirection);
                transform.position += m_currentDirection * m_moveSpeed * Time.deltaTime;

                m_animator.SetFloat("MoveSpeed", direction.magnitude);
            }


        }

    }



    public void GoToBed(Transform bed, Transform lookAtTarget)
    {
        bedPosition = bed;
        transform.position = bed.position + new Vector3(0, 7, 10);

        Vector3 direction = (lookAtTarget.position - gameObject.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(0, direction.y, direction.z));
        transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, lookRotation, Time.deltaTime * 3);
        inBed = true;
        m_animator.SetFloat("MoveSpeed", 0);
        if (Time.time > lastNote + 25)
        {
            gameControllerScript.showNote();
            lastNote = Time.time;
        }

    }

    private void WakeUp()
    {

        gameControllerScript.setCurrentTask(GameController.TasksEnum.Switch);
        gameControllerScript.addTask(3);
        transform.position = bedPosition.position + new Vector3(-10, 0, 20);
        inBed = false;
        m_animator.SetBool("Grounded", m_isGrounded);
        DirectUpdate();
        lastNote = Time.time;
    }

    public void reset() {
        texto.SetActive(false);
        gameObject.transform.position = new Vector3(3.8f, 0.0f, 116.5f);
        gameObject.transform.eulerAngles = new Vector3(0.0f, 45.0f, 0.0f);
        inBed = false;
    }

}
