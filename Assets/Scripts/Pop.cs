using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pop : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private ForceMode forceMode;
    [SerializeField] private Vector3 forceDirection;

    private void OnEnable()
    {
        rb.AddForce(forceDirection, forceMode);
    }

    private void OnDisable()
    {
        // rb.velocity = Vector3.zero;
    }
}