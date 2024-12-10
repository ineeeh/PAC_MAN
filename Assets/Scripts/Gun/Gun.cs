using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Camera cam;
    private Transform firepointRayDirection;
    private Vector3 destination;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float bulletSpeed = 50; // Bullet speed

    public InputActionReference shootAction; // Reference to the shoot action

    public AudioSource audioSource;

    void Awake()
    {
        shootAction.action.Enable();
        shootAction.action.performed += shootProjectile;

        cam = Camera.main;
    }

    void OnDestroy()
    {
        shootAction.action.Disable();
        shootAction.action.performed -= shootProjectile;
    }

    private void shootProjectile(InputAction.CallbackContext context)
    {
        audioSource.Play();

        // Useful for non-VR games///////////////////////////////////////////////////////////////////////////////////////
        // Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        
        // RaycastHit hit;
        // if (Physics.Raycast(ray, out hit))
        // {
        //     destination = hit.point;
        // }
        // else
        // {
        //     destination = ray.GetPoint(1000);
        // }
        destination = firePoint.position - firePoint.forward * 1000;
        Instantiate(firePoint);
    }

    private void Instantiate(Transform firePoint)
    {
        var projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity) as GameObject;
        projectile.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * 10;
    }
}
