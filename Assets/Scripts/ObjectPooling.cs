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
    [SerializeField] private List<GameObject> ene;
    [SerializeField] private List<GameObject> fir;
    [SerializeField] private List<GameObject> bri;
    [SerializeField] private List<GameObject> wal;
    [SerializeField] private List<GameObject> sti;
    [SerializeField] private List<GameObject> log;
    [SerializeField] private List<GameObject> bridge;
    [SerializeField] private List<GameObject> key;
    [SerializeField] private List<GameObject> spike;
    [SerializeField] private List<GameObject> chai;

    private void OnEnable()
    {
        EventManager.clearcount += clearCounter;
    }

    private void OnDestroy()
    {
        EventManager.clearcount -= clearCounter;
    }

    private void Awake()
    {
        sharedInstance = this;
    }

    private void Start()
    {
        foreach (var item in objectsToSpawn)
        {
            counterLists.Add(4);
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
        else if (index == 6)
        {
            ene.Add(tmp);
        }
        else if (index == 7)
        {
            fir.Add(tmp);
        }
        else if (index == 8)
        {
            bri.Add(tmp);
        }
        else if (index == 9)
        {
            wal.Add(tmp);
        }
        else if (index == 10)
        {
            sti.Add(tmp);
        }
        else if (index == 11)
        {
            log.Add(tmp);
        }
        else if (index == 12)
        {
            bridge.Add(tmp);
        }
        else if (index == 13)
        {
            key.Add(tmp);
        }
        else if (index == 14)
        {
            spike.Add(tmp);
        }
        else if (index == 15)
        {
            chai.Add(tmp);
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
        else if (index == 6)
        {
            ene[counterLists[index]].SetActive(false);
            return ene;
        }
        else if (index == 7)
        {
            fir[counterLists[index]].SetActive(false);
            return fir;
        }
        else if (index == 8)
        {
            bri[counterLists[index]].SetActive(false);
            return bri;
        }
        else if (index == 9)
        {
            wal[counterLists[index]].SetActive(false);
            return wal;
        }
        else if (index == 10)
        {
            sti[counterLists[index]].SetActive(false);
            return sti;
        }
        else if (index == 11)
        {
            log[counterLists[index]].SetActive(false);
            return log;
        }
        else if (index == 12)
        {
            bridge[counterLists[index]].SetActive(false);
            return bridge;
        }
        else if (index == 13)
        {
            key[counterLists[index]].SetActive(false);
            return key;
        }
        else if (index == 14)
        {
            spike[counterLists[index]].SetActive(false);
            return spike;
        }
        else if (index == 15)
        {
            chai[counterLists[index]].SetActive(false);
            return chai;
        }
        else
        {
            return null;
        }
    }

    private void clearCounter(int index)
    {
        if (counterLists[index] > 0)
        {
            counterLists[index]--;
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
        Debug.Log(index);
        int tmpcount = counter(index);
        List<GameObject> pooledObjects = DetermineList(index);

        return pooledObjects[tmpcount]; // this needs to be 1-3
    }
}