using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class Grab : MonoBehaviour
{
    [SerializeField] private bool isGrabbed;
    [SerializeField] private Vector3 mousePos;
    [SerializeField] private float interpolation;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 dragScale;
    [SerializeField] private Vector3 originalScale;

    private void OnEnable()
    {
        EventManager.onraycast += CheckTransform;
    }

    private void OnDisable()
    {
        EventManager.onraycast -= CheckTransform;
    }

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        originalScale = transform.localScale;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            rb.useGravity = true;
            isGrabbed = false;
            transform.localScale = originalScale;
        }

        if (isGrabbed)
        {
            rb.useGravity = false;
            DoGrab();
        }
    }

    private void CheckTransform(GameObject hitObjectFromRay)
    {
        if (hitObjectFromRay == transform.gameObject)
        {
            isGrabbed = true;
            transform.localScale = transform.localScale + dragScale;
            rb.velocity = Vector3.zero;
        }
        else if (hitObjectFromRay == null || hitObjectFromRay != this)
        {
            isGrabbed = false;
            return;
        }
    }

    private void DoGrab()
    {
        mousePos = Input.mousePosition;
        mousePos.z = transform.position.z - Camera.main.transform.position.z;
        transform.position = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(mousePos), interpolation);
    }
}