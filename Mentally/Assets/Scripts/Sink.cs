using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{

    [SerializeField] Transform character;



    float nextTime = 0;
    private static float timeInBetween = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(character.position, gameObject.transform.position);
        if (dist <= 14 && Input.GetKey(KeyCode.Space) && Time.time >= nextTime)
        {
            nextTime += timeInBetween;
            FindObjectOfType<AudioManager>().Play("waterPouring");

        }
    }
}
