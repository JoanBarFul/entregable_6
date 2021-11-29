using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRigidbody;
    public float jumpForce = 5f;
    public float gravityMod = 1f;
    private float limY = 14f;
    public bool isOnGround = true;
    public bool gameOver = false;
    private AudioSource playerAudio;
    public AudioClip jumpClip;
    public AudioClip colisionClip;
    public ParticleSystem particlesExplosion;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
        playerAudio = GetComponent<AudioSource>();
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && transform.position.y < limY)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpClip, 1);
        }
        if (transform.position.y >= limY)
        { transform.position = new Vector3(transform.position.x, limY, transform.position.z); }
    }

    public void OnCollisionEnter(Collision otherCollider)
    { if (!gameOver)
        {
            if (otherCollider.gameObject.CompareTag("Ground"))
            {
                Debug.Log("GAME OVER");
                gameOver = true;
                Destroy(gameObject);
                
            }
            if (otherCollider.gameObject.CompareTag("Obstacle"))
            {
                Debug.Log("GAME OVER");
                playerAudio.PlayOneShot(colisionClip, 1);
                //particlesExplosion.Play();
                gameOver = true;
                Destroy(gameObject);

            }



        }
    }
}
