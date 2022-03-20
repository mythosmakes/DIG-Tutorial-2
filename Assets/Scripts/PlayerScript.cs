using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public Text score;
    public Text lives;
    public GameObject win;
    public GameObject lose;
    public GameObject player;

    public float hozMovement;
    public float vertMovement;

    private Rigidbody2D rd2d;
    private int scoreValue = 0;
    private int livesValue = 3;
    private int level = 1;
    private bool facingRight = true;
    private bool jump;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();

        score.text = "Score: " + scoreValue.ToString();
        lives.text = "Lives: " + livesValue.ToString();

        win.SetActive(false);
        lose.SetActive(false);

        anim = GetComponent<Animator>();
    }

     // physics
    void FixedUpdate()
    {
        hozMovement = Input.GetAxis("Horizontal");
        vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));

        if (facingRight == false && hozMovement > 0f)
        {
            Flip();
        }
        else if (facingRight == true && hozMovement < 0f)
        {
            Flip();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (jump == true)
        {
            anim.SetInteger("State", 2);
        }

        if (jump == false)
        {
            if (hozMovement != 0)
            {
                anim.SetInteger("State", 1);
            }

            else
            {
                anim.SetInteger("State", 0);
            }
        }
    }

    // entity collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = "Score: " + scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }

         if (collision.collider.tag == "Enemy")
        {
            livesValue = livesValue - 1;
            lives.text = "Lives: " + livesValue.ToString();
            Destroy(collision.collider.gameObject);
        } 

        if (scoreValue == 4 && level == 1)
        {
            Teleport();

            livesValue = 3;
            lives.text = "Lives: " + livesValue.ToString();
        }

        if (scoreValue == 8)
        {
            win.SetActive(true);
            player.SetActive(false);
        }

        if (livesValue == 0)
        {
            lose.SetActive(true);
            player.SetActive(false);
        }
    }

    // ground stuff
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            if (vertMovement == 0)
            {
                jump = false;
            }

            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3.5f), ForceMode2D.Impulse);
               
                if (vertMovement > 0)
                {
                jump = true;
                }
            }
        }
    }

    // flip anim
    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    // level 2 teleport
    void Teleport()
    {
        transform.position = new Vector2(35.0f, -2.0f);

        level = 2;
    }
}
