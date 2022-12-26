using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public Sprite trueText;
    public Sprite fasleText;

    private string purple = "Purple";
    private string pink = "Pink";
    private string darkBlue = "DarkBlue";
    private string ligthBlue = "LightBlue";

    private GameObject[] texts;
    private GameObject[] pieces;

    public Vector2 objPos1;
    public Vector2 objPos2;

    void Start()
    {
        texts = GameObject.FindGameObjectsWithTag("TextPuzzle");
        pieces = GameObject.FindGameObjectsWithTag("PuzzlePiece");
    }

    void Update()
    {  
        double eps = 0.001;

        for(int i = 0; i < texts.Length; i++)
        {
            for(int j = 0; j < pieces.Length; j++)
            {
                for(int k = 1; k < pieces.Length; k++)
                {
                    if (j == k) continue;

                    if (Math.Abs(pieces[j].transform.position.x - pieces[k].transform.position.x) < eps &&
                        Math.Abs(texts[i].transform.position.x - pieces[j].transform.position.x) < eps) 
                    {
                        if ((pieces[j].name.Contains(pink)       && pieces[k].name.Contains(darkBlue))  ||
                            (pieces[j].name.Contains(darkBlue)   && pieces[k].name.Contains(pink))      ||
                            (pieces[j].name.Contains(purple)     && pieces[k].name.Contains(ligthBlue)) ||
                            (pieces[j].name.Contains(ligthBlue)  && pieces[k].name.Contains(purple)))
                        {
                            texts[i].GetComponent<SpriteRenderer>().sprite = trueText;
                        }
                        else
                        {
                            texts[i].GetComponent<SpriteRenderer>().sprite = fasleText;
                        }
                    }
                }
            }
        }
    }
}
