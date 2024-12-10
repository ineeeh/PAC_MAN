using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke();

    }
}
