using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2; // Bullet life time
    private bool colided = false;
    public AudioSource audioSource;
    
    void Awake()
    {
        // Destroy the bullet after the life time
        //Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet" && !colided)
        {
            colided = true;
            audioSource.Play();
            Destroy(gameObject);

            if (collision.gameObject.tag == "PacMan")
            {
                collision.gameObject.GetComponent<RandomMovement>().canMove = false;
            }

        }
         

    }
}
 