using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] Transform horizontalPoint;
    [SerializeField] Transform verticalPoint;
    [SerializeField] float speed = 0.1f;

    private Vector3 _startHorizontalPoint;
    private Vector3 _startVerticalPosition;

    private bool _toRight = true;
    private bool _horizontalMove = true;
    private bool _toDown = true;

    private bool testStop = false;

    private GameObject _wallBrick;
    private BrickWallController _brickWallController;
    // Start is called before the first frame update
    void Start()
    {
        _startHorizontalPoint = transform.position;
        _brickWallController = GameObject.FindGameObjectWithTag("BrickWall").GetComponent<BrickWallController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_horizontalMove)
            {
                _horizontalMove = false;
                _startVerticalPosition = transform.position;
            }
            else
            {
                _wallBrick = _brickWallController.GetNearestBrick(transform);
                _wallBrick.GetComponent<SpriteRenderer>().enabled = true;
                transform.position = _startHorizontalPoint;
                _horizontalMove = true;
                _toDown = true;
                _toRight = true;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(_horizontalMove)
        {
            if (_toRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, horizontalPoint.position, speed);
                if (Vector3.Distance(horizontalPoint.position, transform.position) < 0.1)
                {
                    _toRight = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _startHorizontalPoint, speed);
                if (Vector3.Distance(transform.position, _startHorizontalPoint) < 0.1)
                {
                    _toRight = true;
                }
            }
        }
        else
        {
            if(_toDown)
            {
                Vector3 dir = verticalPoint.position;
                dir.x = transform.position.x;
                transform.position = Vector3.MoveTowards(transform.position, dir, speed);
                if(Vector3.Distance(dir, transform.position) < 0.1)
                {
                    _toDown = false;
                }
            }
            else
            {
                Vector3 dir = verticalPoint.position;
                dir.x = transform.position.x;
                transform.position = Vector3.MoveTowards(transform.position, _startVerticalPosition, speed);
                if (Vector3.Distance(_startVerticalPosition, transform.position) < 0.1)
                {
                    _toDown = true;
                }
            }
        }
        
    }
}
