using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolPuzzlePart : MonoBehaviour
{
    public bool isActive;

    public Sprite normalSprite;
    public Sprite activeSprite;

    private GameObject[] elements;
    private BoolPuzzlePart boolPuzzlePartScript;

    void Start()
    {
        isActive = false;
        elements = GameObject.FindGameObjectsWithTag("PuzzlePiece");
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int count = 0;
            bool isSwap = false;
            foreach(var obj in elements)
            {
                boolPuzzlePartScript = obj.GetComponent<BoolPuzzlePart>();
                if (boolPuzzlePartScript.isActive)
                {
                    isSwap = true;
                    break;
                }
                count++;
            }

            if (isSwap)
            {
                var tmp = elements[count].transform.position;
                elements[count].transform.position = this.gameObject.transform.position;;
                this.gameObject.transform.position = tmp;
                boolPuzzlePartScript = elements[count].GetComponent<BoolPuzzlePart>();
                elements[count].GetComponent<SpriteRenderer>().sprite = boolPuzzlePartScript.GetComponent<BoolPuzzlePart>().normalSprite;
                boolPuzzlePartScript.isActive = false;
                isSwap = false;
            }
            else 
            {
                this.isActive = true;
                this.GetComponent<SpriteRenderer>().sprite = activeSprite;
            }
        }
    }
}
