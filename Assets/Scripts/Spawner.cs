using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int objCount;
    [SerializeField] private int objCounter;
    [SerializeField] private Transform spawnPos;

    // Start is called before the first frame update
    private void Start()
    {
    }

    public void SpawnObjects(int index)
    {
        //objCounter++; // this counter needs to be for each object not total.
        //if (objCounter == 4)
        //{
        //    objCounter = 0;
        //}
        GameObject obj = ObjectPooling.sharedInstance.SpawnPooledObject(objCount, index);
        if (!obj.activeInHierarchy)
        {
            obj.transform.position = spawnPos.position;
            obj.SetActive(true);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}