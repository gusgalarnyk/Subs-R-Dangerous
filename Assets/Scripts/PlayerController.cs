using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb2d;
    private string nextDir;
    private string lastDir;

    Vector2 dest = Vector2.zero;

    bool valid(Vector2 dir)
    {
        // Cast Line from 'next to player' to 'player'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);

        bool isWall;
        if (hit.collider.name == "Background")
        {
            isWall = false;
        }
        else
        {
            isWall = true;
        }

        return (isWall);
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        dest = transform.position;
        nextDir = "";
        lastDir = "";
    }

    void FixedUpdate()
    {
        // Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            nextDir = "u";
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            nextDir = "r";
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            nextDir = "d";
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            nextDir = "l";
        }

        // Check for Input if not moving
        if ((Vector2)transform.position == dest)
        {
            if (nextDir == "u" && valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
                lastDir = "u";
            }
            else if (nextDir == "r" && valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
                lastDir = "r";
            }
            else if (nextDir == "d" && valid(-Vector2.up))
            {
                dest = (Vector2)transform.position - Vector2.up;
                lastDir = "d";
            }
            else if (nextDir == "l" && valid(-Vector2.right))
            {
                dest = (Vector2)transform.position - Vector2.right;
                lastDir = "l";
            }
            else if (lastDir == "u" && valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
            }
            else if (lastDir == "r" && valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
            }
            else if (lastDir == "d" && valid(-Vector2.up))
            {
                dest = (Vector2)transform.position - Vector2.up;
            }
            else if (lastDir == "l" && valid(-Vector2.right))
            {
                dest = (Vector2)transform.position - Vector2.right;
            }

            /* One for One movement
            if (Input.GetKey(KeyCode.UpArrow) && valid(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;
                lastDir = "u";
            }
                
            if (Input.GetKey(KeyCode.RightArrow) && valid(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;
                lastDir = "r";
            }
                
            if (Input.GetKey(KeyCode.DownArrow) && valid(-Vector2.up))
            {
                dest = (Vector2)transform.position - Vector2.up;
                lastDir = "d";
            }
                
            if (Input.GetKey(KeyCode.LeftArrow) && valid(-Vector2.right))
            {
                dest = (Vector2)transform.position - Vector2.right;
                lastDir = "l";
            }
            */
        }
    }

	void Update ()
	{
		
	}
}