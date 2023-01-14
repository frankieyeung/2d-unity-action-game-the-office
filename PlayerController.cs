using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public float speed;
    Animator animator;
    float jumpForce = 800.0f;
    private bool isOnGround;
    GameObject director;
    // Start is called before the first frame update




    void Start()
    {
        
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.director = GameObject.Find("GameDirector");
    }

    // Update is called once per frame

    void Update()
    {

        //Jump
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround) 
        {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        Move();
        
        //speed
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);


        if(isOnGround) {
            this.animator.speed = speedx / 2.0f;
        } else {
            this.animator.speed = 0.5f;
        }


        //move left and right
        int key = 0;
        if(Input.GetKey(KeyCode.LeftArrow)) key = -1;
        if(Input.GetKey(KeyCode.RightArrow)) key = 1;


        //flip character when moving forward or backward
        if(key != 0) {
            transform.localScale = new Vector3(key, 1, 1);
        }





        //if player go left,restart game
        if(transform.position.x < -9 ) {
            SceneManager.LoadScene("GameScene");
        }


    }


    private void Move() {
        float x = Input.GetAxisRaw("Horizontal");
        float move = x * speed;
        rigid2D.velocity = new Vector2(move, rigid2D.velocity.y);
    }

    //finish collision
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "finish") {
            Debug.Log("Finish");
            SceneManager.LoadScene("winScene");
        }
            
        if(other.gameObject.tag == "coin") {
            Debug.Log("Tag=coin");
            this.director.GetComponent<GameDirector>().getCoin();
            Destroy(other.gameObject);
        }
        
        if(other.gameObject.tag == "poop") {
            Debug.Log("Tag=poop");
            this.director.GetComponent<GameDirector>().getPoop();
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "icecream") {
            Debug.Log("Tag=icecream");
            this.director.GetComponent<GameDirector>().getIcecream();
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "bamboo") {
            Debug.Log("Tag=bamboo");
            this.director.GetComponent<GameDirector>().getBamboo();
            Destroy(other.gameObject);
        }

            
        }


    // onGround checking
    private void OnCollisionEnter2D(Collision2D collision) {

            if(CollisionIsWithGround(collision)) {
                isOnGround = true;
            }
    }

    private void OnCollisionExit2D(Collision2D collision) {
            if(!CollisionIsWithGround(collision)) {
                isOnGround = false;
            }
    }

    private bool CollisionIsWithGround(Collision2D collision) {
            bool isWithGround = false;
            foreach(ContactPoint2D c in collision.contacts) {
                Vector2 collisionDirection = c.point - rigid2D.position;
                if(collisionDirection.y < 0) {
                    isWithGround = true;
                }
            }
            return isWithGround;
    }
}
