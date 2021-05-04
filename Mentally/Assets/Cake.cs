using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour

{
    [SerializeField] GameObject cakes;
    [SerializeField] Transform character;

    private static int totalPiezas = 11;
    private int piezaActual = 0; 
    GameObject hijo;

    float nextPiece = 0;
    private static float timeInBetween = 10;
    private bool endedCake = false; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(character.position, cakes.transform.position);
        if (!endedCake && dist <= 14 && Input.GetKey(KeyCode.Space) && Time.time >= nextPiece) {
            nextPiece += timeInBetween;
            if (piezaActual < totalPiezas)
            {
                hijo = cakes.transform.GetChild(piezaActual).gameObject;
                hijo.active = false;
                piezaActual++;
                Debug.Log("pos me la llevo");
            }
            else {
                endedCake = true; 
            }
        }
        
    }
}
