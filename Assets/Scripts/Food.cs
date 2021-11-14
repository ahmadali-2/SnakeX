using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        RandomizePosition();
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.boxCollider2D.bounds;
        int x = (int)Random.Range(bounds.min.x, bounds.max.x) - 1;
        int y = (int)Random.Range(bounds.min.y, bounds.max.y) - 1;

        this.transform.position = new Vector2(x,y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "snake")
        {
            RandomizePosition();
        }
    }
}
