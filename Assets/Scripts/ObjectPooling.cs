using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooling : MonoBehaviour
{
    public int amountToPool; // this should be how many for each object.

    [SerializeField] private GameObject[] objectsToSpawn; // The prefab of the object you want to spawn
    public static ObjectPooling sharedInstance;

    public GameObject poolingObject;

    [SerializeField] private List<int> counterLists;

    [SerializeField] private List<GameObject> tri;
    [SerializeField] private List<GameObject> cir;
    [SerializeField] private List<GameObject> squ;
    [SerializeField] private List<GameObject> dia;
    [SerializeField] private List<GameObject> sta;
    [SerializeField] private List<GameObject> dro;

    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        foreach (var item in objectsToSpawn)
        {
            counterLists.Add(0);
        }

        GameObject tmp;
        for (int j = 0; j < objectsToSpawn.Length; j++)
        {
            for (int i = 0; i < amountToPool; i++)
            {
                poolingObject = objectsToSpawn[j];
                tmp = Instantiate(poolingObject);
                tmp.name = objectsToSpawn[j].name + i;
                tmp.SetActive(false);

                SeperateList(j, tmp);
            }
        }
    }

    public void SeperateList(int index, GameObject tmp)
    {
        if (index == 0)
        {
            tri.Add(tmp);
        }
        else if (index == 1)
        {
            cir.Add(tmp);
        }
        else if (index == 2)
        {
            squ.Add(tmp);
        }
        else if (index == 3)
        {
            dia.Add(tmp);
        }
        else if (index == 4)
        {
            sta.Add(tmp);
        }
        else if (index == 5)
        {
            dro.Add(tmp);
        }
    }

    public List<GameObject> DetermineList(int index)
    {
        if (index == 0)
        {
            tri[counterLists[index]].SetActive(false);
            return tri;
        }
        else if (index == 1)
        {
            cir[counterLists[index]].SetActive(false);
            return cir;
        }
        else if (index == 2)
        {
            squ[counterLists[index]].SetActive(false);
            return squ;
        }
        else if (index == 3)
        {
            dia[counterLists[index]].SetActive(false);
            return dia;
        }
        else if (index == 4)
        {
            sta[counterLists[index]].SetActive(false);
            return sta;
        }
        else if (index == 5)
        {
            dro[counterLists[index]].SetActive(false);
            return dro;
        }
        else
        {
            return null;
        }
    }

    private int counter(int index)
    {
        counterLists[index]++;

        Debug.Log(counterLists[index]);
        if (counterLists[index] == 4)
        {
            counterLists[index] = 0;
        }
        return counterLists[index];
    }

    public GameObject SpawnPooledObject(int amount, int index)
    {
        int tmpcount = counter(index);
        List<GameObject> pooledObjects = DetermineList(index);

        return pooledObjects[tmpcount]; // this needs to be 1-3
    }
}