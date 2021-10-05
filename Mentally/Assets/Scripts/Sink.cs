using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{

    [SerializeField] GameObject character;
    [SerializeField] private Animator m_animator = null;


    private float nextTime = 0;
    private static float timeInBetween = 10;
    // Start is called before the first frame update
    void Start()
    {

        if (!m_animator) { character.GetComponent<Animator>(); }
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(character.transform.position, gameObject.transform.position);
        if (dist <= 14 && Input.GetKey(KeyCode.Space) && Time.time >= nextTime)
        {
            m_animator.SetBool("Pickup", true);
            nextTime += timeInBetween;
            FindObjectOfType<AudioManager>().Play("waterPouring");

        }
    }
}
