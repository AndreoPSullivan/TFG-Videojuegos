using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{

    [SerializeField] GameObject character;
    [SerializeField] Transform bed;
    [SerializeField] GameObject controller;
    [SerializeField] Transform lookAtBed; 

    private GameController gameController;
    private SimpleSampleCharacterControl characterScript;
    public bool sleeping = false; 
    // Start is called before the first frame update
    void Start()
    {  
        // Find the Enemy script attached to "myEnemy"
        gameController = controller.GetComponent<GameController>();

        characterScript = character.GetComponent<SimpleSampleCharacterControl>();
    }

    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(character.transform.position, bed.position);
        if (dist <= 13 && !sleeping){
            gameController.addTask(1);
            characterScript.GoToBed(bed, lookAtBed);
        }
    }
}
