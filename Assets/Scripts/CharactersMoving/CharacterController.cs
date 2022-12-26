using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //public Vector2 coords = rigidbody2d.position;

    Rigidbody2D rigidbody2d;
    float horizontal; 
    float vertical;

    public float speed;

    public GameObject CanvasPuzzle;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //puzzlePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanvasPuzzle.activeSelf) {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");    
        }
        else
        {
            horizontal = 0f; 
            vertical = 0f;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        

        rigidbody2d.MovePosition(position);
    }

    // void OnTriggerEnter2D(Collider2D col)
    // {
    //     if (col.gameObject.name.Equals("ThirdRoomInteraction"))
    //         CanvasPuzzle.SetActive(true);
    // }

    // void OnTriggerExit2D(Collider2D col)
    // {
    //     if (col.gameObject.name.Equals("ThirdRoomInteraction")){
    //         CanvasPuzzle.SetActive(false);
    //     }
    // }
}
