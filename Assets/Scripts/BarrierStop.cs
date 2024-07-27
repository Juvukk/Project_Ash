using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierStop : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}