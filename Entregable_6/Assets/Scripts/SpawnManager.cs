using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private float startDelay = 0.5f;
    private float repeatRate = 3f;
    public int left = 0;
    public int right = 1;
    private Quaternion roffset = Quaternion.Euler(0, 180, 0);
    //private float spawnRL;
   
    private Vector3 spawnPos;
    private float ranY;
    public float ranX;
    public PlayerController playerControllerScript;
    


    void Start()
    {
        InvokeRepeating("Spawner", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
       

    }


   
    private void Spawner()
    {
        if (!playerControllerScript.gameOver)
        {      
            ranY = Random.Range(2, 13);
            ranX = Random.Range(0, 2);

            if (ranX == left)
            {
                spawnPos = new Vector3(-13, ranY, 0);
                Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
                
            }  
             if (ranX == right)
            {
                spawnPos = new Vector3(13, ranY, 0);
                Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation * roffset);
                
            }
         }

           








        }

    }

