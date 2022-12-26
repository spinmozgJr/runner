using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoublePuzzle : MonoBehaviour
{
    public bool finish;
    private GameObject[] pieces;
    private MovingSystem movingSystemScript;
    private PartsMovingSystem partsMovingSystemScript;
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
                if (item.GetComponent<MovingSystem>() != null) 
                {
                    if (!item.GetComponent<MovingSystem>().finish){
                        ifOneFalse = true;
                        break;
                    }
                    continue;
                }
                
                if (item.GetComponent<PartsMovingSystem>() != null) 
                {
                    if (!item.GetComponent<PartsMovingSystem>().finish){
                        ifOneFalse = true;
                        break;
                    }
                }

                //movingSystemScript = item.GetComponent<MovingSystem>();
                //partsMovingSystemScript = item.GetComponent<PartsMovingSystem>();
                //if (!movingSystemScript.finish || !partsMovingSystemScript.finish)
            //     if (movingSystemScript != null)
            //     {
                    
            //     }
            //     else{
            //         if (!partsMovingSystemScript.finish)
            //         {
            //             ifOneFalse = true;
            //             break;
            //         }
            //     }   
            }

            if (!ifOneFalse)
            {
                end = true;
            } 
        }    
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        
    }
}
