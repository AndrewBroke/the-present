using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    [SerializeField] private GameObject bigBrick;
    [SerializeField] private GameObject smallBrick;


    private float _wallX, _wallY;
    private float _bigBrickX, _bigBrickY;
    private float _smallBrickX, _smallBrickY;
    // Start is called before the first frame update
    void Start()
    {
        // Получение размера стенки
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        _wallX = spriteRenderer.sprite.texture.width * transform.localScale.x;
        _wallY = spriteRenderer.sprite.texture.height * transform.localScale.y;

        Transform brickTransform;
        // Получение размера большого кирпича
        spriteRenderer = bigBrick.GetComponent<SpriteRenderer>();
        brickTransform = bigBrick.GetComponent<Transform>();
        _bigBrickX = spriteRenderer.sprite.bounds.size.x * spriteRenderer.sprite.pixelsPerUnit * brickTransform.localScale.x;
        _bigBrickY = spriteRenderer.sprite.bounds.size.y * spriteRenderer.sprite.pixelsPerUnit * brickTransform.localScale.y;

        // Получение размера маленького кирпича
        spriteRenderer = smallBrick.GetComponent<SpriteRenderer>();
        brickTransform = smallBrick.GetComponent<Transform>();
        _smallBrickX = spriteRenderer.sprite.bounds.size.x * spriteRenderer.sprite.pixelsPerUnit * brickTransform.localScale.x;
        _smallBrickY = spriteRenderer.sprite.bounds.size.y * spriteRenderer.sprite.pixelsPerUnit * brickTransform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
