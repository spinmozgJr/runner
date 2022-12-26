using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPuzzle : MonoBehaviour
{
    public bool finish;
    private GameObject[] pieces;
    private MovingSystem movingSystemScript;
    public bool end;
    
    void Start()
    {
        finish = false;
        end = false;
        pieces = GameObject.FindGameObjectsWithTag("PuzzlePiece");
    }

    // Update is called once per frame
    void Update()
    {   
        if (!end)
        {
            bool ifOneFalse = false;
            foreach(var item in pieces)
            {
                movingSystemScript = item.GetComponent<MovingSystem>();
                if (!movingSystemScript.finish) ifOneFalse = true; 
            }
            if (!ifOneFalse) end = true;
        }    
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        
    }
}
