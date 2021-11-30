using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLateral : MonoBehaviour
{
    public float speed = 6f;
    private float destroyLimR = 20f;
    private float destroyLimL = -20f;
    public PlayerController playerControllerScript;
    
    
    void Start()
    {playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();}


    void Update()
    {
            if (!playerControllerScript.gameOver)
            { transform.Translate(Vector3.right * speed * Time.deltaTime); }

            else { Destroy(gameObject); }

            if (transform.position.x >= destroyLimR || transform.position.x <= destroyLimL)
            { Destroy(gameObject); }
    }
}
