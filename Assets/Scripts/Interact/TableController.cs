using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableController : MonoBehaviour
{
    public GameObject CanvasPuzzle;
    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openPuzlle()
    {
        CanvasPuzzle.SetActive(true);
        isOpen = true;
    }

    public void closePuzzle()
    {
        CanvasPuzzle.SetActive(false);
        isOpen = false;
    }
    
}
