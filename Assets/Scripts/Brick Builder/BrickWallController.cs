using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickWallController : MonoBehaviour
{

    private GameObject[] _bricks;
    // Start is called before the first frame update
    void Start()
    {
        _bricks = GameObject.FindGameObjectsWithTag("Brick");
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Generate()
    {
        foreach (var brick in _bricks)
        {
            brick.GetComponent<SpriteRenderer>().enabled = true;
        }

        for (int i = 0; i < 15; i++)
        {
            int deleteIndex = Random.Range(0, _bricks.Length);
            while (!_bricks[deleteIndex].GetComponent<SpriteRenderer>().enabled)
            {
                deleteIndex = Random.Range(0, _bricks.Length);
            }
            _bricks[deleteIndex].GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public GameObject GetNearestBrick(Transform pos)
    {
        float distance = 100f;
        GameObject nearestBrick = null;
        foreach (var brick in _bricks)
        {
            float currentDistance = Vector3.Distance(brick.GetComponent<Transform>().position, pos.position);
            if (currentDistance < distance)
            {
                if (!brick.GetComponent<SpriteRenderer>().enabled)
                {
                    distance = currentDistance;
                    nearestBrick = brick;
                }
                
            }
        }

        return nearestBrick;
    }
}
