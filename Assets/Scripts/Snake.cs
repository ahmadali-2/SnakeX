using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int snakeSize = 4;
    // Update is called once per frame
    private void Start()
    {
        ResetState();
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }
    }
    
    private void FixedUpdate()
    {
        for(int i=_segments.Count-1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;    
        }

        this.transform.position = new Vector2(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y
        );
    }

    public void ResetState()
    {
        for(int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        for(int i = 1; i < this.snakeSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }

        this.transform.position = Vector2.zero;
    }

    private void GrowSnake()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "food")
        {
            GrowSnake();
        }
        if(collision.tag == "walls")
        {
            ResetState();
        }
    }
}
