using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RoomRandomiser : MonoBehaviour
{
    [SerializeField] private List<GameObject> maps;

    public void getNewMap()
    {
        int rand = Random.Range(0, maps.Count);

        foreach (var item in maps)
        {
            item.SetActive(false);
        }
        maps[rand].SetActive(true);
    }
}