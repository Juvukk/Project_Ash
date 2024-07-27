using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Raycast : MonoBehaviour
{
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask hitLayers;
    [SerializeField] private GameObject hitobject;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DoRayCast();

            if (EventManager.onraycast != null)
            {
                EventManager.onraycast(hitobject);
            }
        }
    }

    public void DoRayCast()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayDistance, hitLayers) && hitobject == null || Physics.Raycast(ray, out hit, rayDistance, hitLayers) && hitobject != hit.transform.gameObject)
        {
            Debug.Log(hit.transform.name);
            hitobject = hit.transform.gameObject;
        }
    }
}