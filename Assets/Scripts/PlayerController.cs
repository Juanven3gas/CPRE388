using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    //public float speed = .1f;

    public Text countText;
    float dirX;
    float dirY;

    private int cout;
    private Vector2 destination = Vector2.zero;
    private Rigidbody2D rb; 
    private CircleCollider2D circleCollider;
    private Animator animator;
    private DataController dataController;
    

	// Use this for initialization
	void Start () {
        dataController = FindObjectOfType<DataController>();
        cout = 0;
        setCountText();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        circleCollider = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        destination = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public int getScore()
    {
        return cout;
    }

    private void FixedUpdate()
    {
        //New way to move packman with button
        //the rigidbody handles collision so packman won't go through walls
        //Still need to fix animation direction
        dirX = CrossPlatformInputManager.GetAxis("Horizontal");
        dirY = CrossPlatformInputManager.GetAxis("Vertical");
        Debug.Log(dirX);
        rb.velocity = new Vector2(dirX * 120, dirY * 120);
        animator.SetFloat("DirX", dirX * 100);
        animator.SetFloat("DirY", dirY * 100);

        //Moves packman one unit over but checks to see if it is a valid move
        /*if(Input.GetKey(KeyCode.UpArrow) && validMove(Vector2.up))
        {
            rb.MovePosition(rb.position + Vector2.up * .2f);
            destination = rb.position + Vector2.up;
        }
        else if(Input.GetKey(KeyCode.DownArrow) && validMove(Vector2.down))
        {
            rb.MovePosition(rb.position + Vector2.down * .2f);
            destination = rb.position + Vector2.down;
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && validMove(Vector2.left))
        {
            rb.MovePosition(rb.position + Vector2.left * .2f);
            destination = rb.position + Vector2.left;
        }
        else if(Input.GetKey(KeyCode.RightArrow) && validMove(Vector2.right))
        {
            rb.MovePosition(rb.position + Vector2.right * .2f);
            destination = rb.position + Vector2.right;
        }*/

        /* changes the direction of the pacman animation
        Vector2 direction = destination - (Vector2)transform.position;
        animator.SetFloat("DirX", direction.x);
        animator.SetFloat("DirY", direction.y);*/
    }

    private bool validMove(Vector2 direction)
    {
        Vector2 start = transform.position;
        Vector2 end = start + direction;
        RaycastHit2D hit;

        circleCollider.enabled = false;
        hit = Physics2D.Linecast(start, end);
        circleCollider.enabled = true;

		if((hit.transform == null) || (hit.collider.name != "maze"))
        {
            return true;
        }
        else
        {
            Debug.Log(hit.collider.name);
            return false;
        }

        /*Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + direction, pos);
        return (hit.collider == GetComponent<Collider2D>());*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PickUp"))
        {
            cout++;
            Destroy(collision.gameObject);
            setCountText();
        }
        else if(collision.gameObject.CompareTag("Ghost"))
        {
            //The game is over so if we did get a highscore then we
            //will submit a change int the score else we will just 
            //show the high score page suggesting that they didn't get a highscore

            if(dataController.GetHighestScore() <= cout)
            {
                dataController.SubmitNewPlayerScore(cout);
                SceneManager.LoadScene("input-initials");
                Destroy(gameObject);
            }
            else
            {
                SceneManager.LoadScene("score");
                Destroy(gameObject);
            }
        }
        else
        {
            //Do Nothing
        }
    }

    private void setCountText()
    {
        countText.text = "Count: " + cout.ToString();
    }
}
