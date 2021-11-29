using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private float startDelay = 1.0f;
    private float repeatRate = 2.5f;
    public int left = 0;
    
    private float spawnRL;
   
    private Vector3 spawnPos;
    private float ranY;
    public float ranX;
    public PlayerController playerControllerScript;
    public moveLateral moveLateralScript;


    void Start()
    {
        InvokeRepeating("Spawner", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        moveLateralScript = GameObject.Find("Bomb").GetComponent<moveLateral>();

    }


   
    private void Spawner()
    {
        if (!playerControllerScript.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        
            spawnPos = new Vector3(spawnRL, ranY, 0);
            ranY = Random.Range(2, 14);
            ranX = Random.Range(0, 2);

            if (ranX == left)
            { spawnRL = -15; }  // Lado random left = 0 --> left  && left = 1 --> right
            else {
                spawnRL = 15;
                moveLateralScript.speed = -moveLateralScript.speed;
           }

           








        }

    }
}
