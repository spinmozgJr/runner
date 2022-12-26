using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSystem : MonoBehaviour
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
        finish = false;
    }

    void Update()
    {
        if (!finish)
        {
            if (moving)
            {
                Vector2 mousePos;
                mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

                this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
            }
        }
        
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !finish)
        {
            Cursor.visible = false; 
            Vector2 mousePos;
            mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        Cursor.visible = true; 
        moving = false;

        var children = correctForm.GetComponentsInChildren<SpriteRenderer>();
        int count = 0;
        bool isSuccess = false;
        foreach (var child in children)
        {
            puzzleSlotScript = child.GetComponent<PuzzleSlot>();
            // Debug.Log(child.name);
            // Debug.Log(Mathf.Abs(this.transform.localPosition.x - child.transform.localPosition.x));
            // Debug.Log(Mathf.Abs(this.transform.localPosition.y - child.transform.localPosition.y));
            // if (Mathf.Abs(this.transform.localPosition.x - child.transform.localPosition.x) <= 0.5f &&
            //     Mathf.Abs(this.transform.localPosition.y - child.transform.localPosition.y) <= 0.5f && 
            //     puzzleSlotScript.isEmpty)
            if (Mathf.Abs(this.transform.position.x - child.transform.position.x) <= 0.5f &&
                Mathf.Abs(this.transform.position.y - child.transform.position.y) <= 0.5f && 
                puzzleSlotScript.isEmpty)
            {
                this.transform.position = new Vector2(child.transform.position.x, child.transform.position.y);
                isSuccess = true;
                finish = true;
                break;
            }
            count++;
        }

        if (isSuccess)
        {
            puzzleSlotScript = children[count].GetComponent<PuzzleSlot>();
            resetPosition = this.transform.localPosition;
            puzzleSlotScript.isEmpty = false;
        } 
        else
        {
            this.transform.localPosition = new Vector2(resetPosition.x, resetPosition.y);
        }
    }
}
