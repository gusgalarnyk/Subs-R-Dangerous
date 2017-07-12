using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterMove : MonoBehaviour
{
    public Transform[] waypoints;

    int cur = 0;

    public float speed;

	void FixedUpdate ()
    {
        Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        float xDiff = transform.position.x - waypoints[cur].position.x;
        float yDiff = transform.position.y - waypoints[cur].position.y;

        if (Mathf.Abs(xDiff) < 0.008 && Mathf.Abs(yDiff) < 0.008)
        {
            float newX = Mathf.Round(transform.position.x);
            float newY = Mathf.Round(transform.position.y);
            print(newX);
            print(newY);
            transform.position.Set(newX, newY, 0f);
            print(transform.position);
            //GetComponent<Rigidbody2D>().MovePosition(moveDamnit);
            print("This doing anything?");
        }

        if ((Vector2)transform.position == (Vector2)waypoints[cur].position)
        {
            cur++;
            print("hit it");
        }
        else
        {
            print("Current position: " + (Vector2)transform.position);
            print("Waypoint position: " + (Vector2)waypoints[cur].position);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
