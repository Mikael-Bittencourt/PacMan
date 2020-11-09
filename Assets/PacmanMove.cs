using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMove : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 dest = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
         GetComponent<Rigidbody2D>().MovePosition(p);

         if ((Vector2)transform.position == dest)
         {
             if(Input.GetKeyDown(KeyCode.UpArrow) && valid(Vector2.up))
             dest = (Vector2)transform.position + Vector2.up;
             if(Input.GetKeyDown(KeyCode.RightArrow) && valid(Vector2.right))
             dest = (Vector2)transform.position + Vector2.right;
             if(Input.GetKeyDown(KeyCode.DownArrow) && valid(-Vector2.up))
             dest = (Vector2)transform.position - Vector2.up;
             if(Input.GetKeyDown(KeyCode.LeftArrow) && valid(-Vector2.right))
             dest = (Vector2)transform.position - Vector2.right;
         }
    }

    bool valid(Vector2 dir)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
    }
}
