using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperController : MonoBehaviour
{
    private GameObject SourceGameObject;
    private Vector2 direction;

    public float moveDistance;
    public float xOffset;
    public float yOffset;

    void Start()
    {
        SourceGameObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 characterCoords = SourceGameObject.transform.position;
        characterCoords.x += xOffset;
        characterCoords.y += yOffset;

        Vector2 position = transform.position;

        if (Vector2.Distance(characterCoords, position) > moveDistance)
        {
            direction = (characterCoords - position).normalized;
            position = (Vector2)transform.position + direction * 0.1f;
            transform.position = position;
        }
    }
}
