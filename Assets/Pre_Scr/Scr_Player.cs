using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player : MonoBehaviour
{
    public float Speed;
    public GameObject Fire;
    public GameObject Normal;
    public GameObject Boom;
    public 
    float xMove;
    public bool InputLeft;
    public bool InputRight;
    public bool InputJump;
    public bool FireDie;
    public bool BoomDie;
    public bool Die;
    public string DieType;
    public AudioClip[] SoundZip;
    AudioSource Aud;
    Rigidbody2D body;
    SpriteRenderer XY;
    Animator Ani;

    // Start is called before the first frame update
    void Start()
    {
        Aud = GetComponent<AudioSource>();
        body = GetComponent<Rigidbody2D>();
        XY = GetComponent<SpriteRenderer>();
        Ani = GetComponent<Animator>();
    }

    void Update()
    {
        ReadyToDie(DieType);
        KillSelf();
        Jump();
        TestMove();







        if(body.velocity.x == 0)
        {
            Ani.SetBool("Walk", false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if(body.velocity.y <= 0)
        {
            Ani.SetBool("Jumping", true);
            GroundCh();
        }
    }


    void Move()
    {
        xMove=0;
        if(InputLeft || Input.GetKey( KeyCode.LeftArrow))
        {
            WallCh("Left");
            XY.flipX = true;
            Ani.SetBool("Walk", true);
        }
        else if(InputRight || Input.GetKey( KeyCode.RightArrow))
        {
            WallCh("Right");
            XY.flipX = false;
            Ani.SetBool("Walk", true);
        }
        else if(!InputRight || !InputLeft)
        {
            body.velocity = new Vector2(0f , body.velocity.y);
        }
        body.AddForce(Vector2.right * xMove , ForceMode2D.Impulse);

        if(body.velocity.x >3.5)
        {
            body.velocity = new Vector2(3.5f , body.velocity.y);
        }
        else if(body.velocity.x < -3.5)
        {
            body.velocity = new Vector2(-3.5f , body.velocity.y);
        }

        
    }


    void Jump()
    {
        if(InputJump && !Ani.GetBool("Jumping")  || Input.GetKeyDown( KeyCode.Space))
        {
            body.AddForce(Vector2.up * 8f , ForceMode2D.Impulse);
            Ani.SetBool("Jumping", true);
            Aud.Play();
        }
    }

    void ReadyToDie(string type)
    {
        switch(type)
        {
            case "fire":
            FireDie = true;
            BoomDie = false;
            break;
            case "boom":
            FireDie = false;
            BoomDie = true;
            break;

            default:
            FireDie = false;
            BoomDie = false;
            break;
        }
    }

    void GroundCh()
    {
        RaycastHit2D ray = Physics2D.Raycast(body.position - new Vector2(0.3f , 0), Vector2.down, 0.6f , LayerMask.GetMask("Tile"));
        RaycastHit2D ray2 = Physics2D.Raycast(body.position, Vector2.down, 0.6f, LayerMask.GetMask("Tile"));
        RaycastHit2D ray3 = Physics2D.Raycast(body.position + new Vector2(0.3f , 0), Vector2.down, 0.6f, LayerMask.GetMask("Tile"));
        if (ray.collider !=null || ray2.collider !=null || ray3.collider != null)
        {
            if(ray.distance < 1f)
            {
               Ani.SetBool("Jumping" , false);
            }
        }
    }

    void WallCh(string dir)
    {
        if (dir == "Right")
        {
            RaycastHit2D ray = Physics2D.Raycast(body.position, Vector2.right, 0.6f, LayerMask.GetMask("Tile"));
            if (ray.collider == null)
            {
                if (ray.distance < 1f)
                {
                    xMove = 1;
                    return;
                }
                else 
                {
                    xMove = 0;
                    return;
                }
            }
        }
        else if (dir == "Left")
        {
            RaycastHit2D ray = Physics2D.Raycast(body.position, Vector2.left, 0.6f, LayerMask.GetMask("Tile"));
            if (ray.collider == null)
            {
                if (ray.distance < 1f)
                {
                    xMove = -1;
                    return;
                }
                else
                {
                    xMove = 0;
                    return;
                }
            }
        }
    }

    void KillSelf()
    {
        if(Die)
        {
            if(FireDie)
            {
                GameObject FireDieObj = Instantiate(Fire,transform.position,transform.rotation);
                gameObject.SetActive(false);
            }
            else if(BoomDie)
            {
                Circle();
                gameObject.SetActive(false);
            }
            else
            return;

            Die=false;
        }
        

    }

    void Circle()
    {
        int num =18;
        for(int i = 0; i < num;)
        {
            
                GameObject boom = Instantiate(Boom, transform.position,transform.rotation);
                Rigidbody2D rigid = boom.GetComponent<Rigidbody2D>();
                Vector2 dirVec = new Vector2(Mathf.Cos(Mathf.PI * 2 * i/num)
                                    ,Mathf.Sin(Mathf.PI * 2 * i/num));

                rigid.AddForce(dirVec.normalized * 15 , ForceMode2D.Impulse);
                i++;
        }
    }











    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spike")
        {
            GameObject FireDie = Instantiate(Normal, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
        
    }








    void TestMove()
    {
        //this.transform.Translate(new Vector3(xMove,0,0));
    }

}
