using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnraycastEvent(GameObject hitObj);

    public static OnraycastEvent onraycast;
}