using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour {

    public Transform[] waypoints;
    public float speed = 0.3f;

    int index = 0;

    private Rigidbody2D rb2d;
    private Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if(transform.position != waypoints[index].position)
        {
            Vector2 newPosition = Vector2.MoveTowards(transform.position, waypoints[index].position, speed);
            rb2d.MovePosition(newPosition);
            Debug.Log("Moving towards position");
        }
        else
        {
            index = (index + 1) % waypoints.Length;
            Debug.Log("New waypoint index is " + index);
        }

        Vector2 dir = waypoints[index].position - transform.position;
        animator.SetFloat("DirX", dir.x);
        animator.SetFloat("DirY", dir.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
