using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class CollectingFruit : MonoBehaviour
{
    public int goalCount = 4;
    public GameObject PacMan;
    public Animator animator;
    int fruitCount = 0;

    public void fruitFound(){
        fruitCount++;
        PacMan.GetComponent<RandomMovement>().speed += 0.5f;
        animator.speed += 0.5f;
        if (fruitCount == goalCount){
            SceneManager.LoadScene("Win");
        }
    }

}
