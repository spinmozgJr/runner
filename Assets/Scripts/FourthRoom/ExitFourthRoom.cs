using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFourthRoom : MonoBehaviour
{
    SpriteRenderer sr;

    void Start()
    {
        sr = GameObject.Find("ThirdRoomTerminal").GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Character"))
        {
            sr.sortingLayerName = "PlayerInFrontOfTable";
        }
    }
}
