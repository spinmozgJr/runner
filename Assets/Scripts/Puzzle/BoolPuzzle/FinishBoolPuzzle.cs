using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBoolPuzzle : MonoBehaviour
{
    private GameObject[] texts;
    private TextManager movingSystemScript;
    public bool end;


    void Start()
    {
        texts = GameObject.FindGameObjectsWithTag("TextPuzzle");
        end = false;
    }

    void Update()
    {
        if (!end)
        {
            bool isOneFalse =  false;
            foreach (var item in texts)
            {
                if (item.GetComponent<SpriteRenderer>().sprite.name.Contains("text_false"))
                {
                    isOneFalse = true;
                }
            }

            if (!isOneFalse) end = true;
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        
    }
}
