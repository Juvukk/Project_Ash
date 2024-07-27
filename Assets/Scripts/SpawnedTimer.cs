using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedTimer : MonoBehaviour
{
    public bool hasRecentlySpawned = true;
    public bool startTimer = true;
    [SerializeField] private float timer = 1;
    private float resetTimer;

    private void OnEnable()
    {
        startTimer = true;
    }

    private void OnDisable()
    {
        hasRecentlySpawned = true;
    }

    private void Start()
    {
        resetTimer = timer;
    }

    // Update is called once per frame
    private void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                startTimer = false;
                hasRecentlySpawned = false;
                timer = resetTimer;
            }
        }
    }
}