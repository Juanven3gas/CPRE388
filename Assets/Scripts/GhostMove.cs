using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour {

    public Transform[] waypoints;
    private float speed = 0.1f;

    int index = 0;

    private Rigidbody2D rb2d;
    private Animator animator;
    private DataController dataController;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        dataController = FindObjectOfType<DataController>();
        setGhostSpeed();
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
            //Debug.Log("Moving towards position");
        }
        else
        {
            index = (index + 1) % waypoints.Length;
            //Debug.Log("New waypoint index is " + index);
        }

        Vector2 dir = waypoints[index].position - transform.position;
        animator.SetFloat("DirX", dir.x);
        animator.SetFloat("DirY", dir.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            
            //Destroy(collision.gameObject);
        }
    }

    private void setGhostSpeed()
    {
        int difficulty = dataController.GetDifficulty();

        switch (difficulty)
        {
            case 1:
                speed = 0.1f;
                break;
            case 2:
                speed = 0.2f;
                break;
            case 3:
                speed = 0.25f;
                break;
            default:
                speed = 0.1f;
                break;
        }
    }
}
