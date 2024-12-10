using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Trigger1 : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;

    void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke();
         if (other.CompareTag("MainCamera"))
        {
            SceneManager.LoadScene("GameOver");
        }

    }
}
