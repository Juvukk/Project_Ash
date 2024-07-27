using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeBookUI : MonoBehaviour
{
    [SerializeField] private bool isopen = true;
    [SerializeField] private Animator bookAni;
    [SerializeField] private GameObject buttons;

    // Start is called before the first frame update
    private void Start()
    {
        SetSize(true);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void OpenClose()
    {
        isopen = !isopen;
        SetSize(isopen);
    }

    private void SetSize(bool isopen)
    {
        bookAni.SetBool("Open", isopen);
        buttons.SetActive(isopen);
    }
}