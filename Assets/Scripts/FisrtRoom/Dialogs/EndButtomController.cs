using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButtomController : MonoBehaviour
{
    public Canvas dialog;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseDialog() 
    {
        dialog.gameObject.SetActive(false);
    }
}
