using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsMovingSystem : MonoBehaviour
{
    public GameObject correctForm;
    private PuzzleSlot puzzleSlotScript;

    private bool moving;
    public bool finish;

    private float startPosX;
    private float startPosY;

    private Vector2 resetPosition;

    void Start()
    {
        resetPosition = this.transform.localPosition;
    }

    void Update()
    {
        if (!finish)
        {
            if (moving)
            {
                Vector2 mousePos;
                mousePos = Input.mousePosition;
                mousePos = mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
            }
        }
        
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.visible = false; 

            Vector2 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        Cursor.visible = true; 
        moving = false;

        // if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 0.5f &&
        //     Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 0.5f && 
        //     child.isEmpty)
        if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= 0.5f &&
            Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= 0.5f)
        {
            this.transform.position = new Vector2(correctForm.transform.position.x, correctForm.transform.position.y);
            puzzleSlotScript = correctForm.GetComponent<PuzzleSlot>();
            puzzleSlotScript.isEmpty = false;
            finish = true;
        }
        else
        {
            this.transform.localPosition = new Vector2(resetPosition.x, resetPosition.y);
        }
    }
}
