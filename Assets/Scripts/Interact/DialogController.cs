using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    public GameObject dialog;
    public bool isOpen;

    void Start()
    {
        isOpen = false;
    }

    public void OpenDialog()
    {
        dialog.SetActive(true);
        isOpen = true;
    }

    public void CloseDialog()
    {
        dialog.SetActive(false);
        isOpen = false;
    }
}
