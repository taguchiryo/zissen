using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{
    public float speed = 10f;
    public float maxspeed = 10f;
    public float jump_force = 500;
    public float jump_x = 0.4f;
    Rigidbody2D player;
    SpriteRenderer player_sprite;
    public SpriteRenderer getSpriteRenderer { get { return player_sprite; } }
    Animator playeranimator;
    Collider2D collder;
    public int hp = 2;
    public int mutekitime = 2;
    public float loop_interval = 0.2f;
    bool muteki = false;
    public bool ground;
    bool Isladderrange;
    public bool getIsladderrange { get { return Isladderrange; } }
    bool climb;
    public bool Climb { set { climb = value; } get { return climb; } }

    float footpos;
    public float Getfootpos { get { return footpos; } }
    float headpos;
    public float Getheadpos { get { return headpos; } }

    float centertofoot;
    public float GetCenterfoot { get { return centertofoot; } }
    //public bool touch_ground = true;
    float scale;
    [SerializeField] private ContactFilter2D filter2d = default;


    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject.GetComponent<Rigidbody2D>();
        player_sprite = this.gameObject.GetComponent<SpriteRenderer>();
        playeranimator = GetComponent<Animator>();
        collder = GetComponent<Collider2D>();
        scale = transform.localScale.y;
        //var text = Resources.Load("Hello") as TextAsset;
        // Debug.Log(text);
        centertofoot = player_sprite.bounds.size.y / 2;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        ground = player.IsTouching(filter2d);
        playeranimator.SetBool("is_ground", ground);
        float yoko = Input.GetAxisRaw("Horizontal");
        bool tate = Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.UpArrow);
        
        footpos = player_sprite.bounds.min.y;
        headpos = player_sprite.bounds.max.y;


        if (ground && yoko == 0)
        {
            player.velocity = new Vector2(0, player.velocity.y);

        }

        if (!climb)
        {
            moveX(yoko);
        }


        if (!Isladderrange)
        {

            if (tate && ground)
            {

                Jump(jump_force);

            }

            if (Mathf.Abs(player.velocity.x) > maxspeed)
            {
                player.velocity = player.velocity.x >= 0 ? new Vector2(maxspeed, player.velocity.y) : new Vector2(-maxspeed, player.velocity.y);
            }

        }



    }


    private void moveX(float yoko)
    {
        if (ground)
        {
            player.AddForce(new Vector2(yoko, -0.2f) * speed * Time.deltaTime * 1000);
        }
        else
        {
            player.AddForce(new Vector2(yoko, 0) * speed * 0.05f * Time.deltaTime * 1000);
        }


        if (yoko != 0)
        {
            playeranimator.SetBool("is_running", true);
            transform.localScale = new Vector3(1 * yoko, 1, 1) * scale;
        }
        else
        {
            playeranimator.SetBool("is_running", false);
        }
    }

    void Jump(float jumpforce)
    {
        playeranimator.SetTrigger("jump");
        player.velocity = new Vector2(player.velocity.x * jump_x, player.velocity.y);
        player.AddForce(new Vector2(0, 1) * jumpforce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
           //ß touch_ground = true;
        }
    }


    public void freezY()
    {
        player.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }
    public void FalsefreezY()
    {
        player.constraints = RigidbodyConstraints2D.None;
        player.freezeRotation = true;
    }

    public void EnableCollider(bool bol)
    {
        collder.enabled = bol;
    }

    public void ClimbAnimation()
    {
        playeranimator.Play("Climb");
    }

    public void IdleAnimation()
    {
        playeranimator.Play("Idle-Animation");
    }
    public void AnimationSpeed(float time)
    {
        playeranimator.speed = time;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("enemy"))
        {
            var enemydata = collision.gameObject.GetComponent<enemy_move>();
            footpos = transform.position.y - centertofoot;
            headpos = player_sprite.bounds.max.y;

          //  Debug.Log("enemy; " + enemydata.transform.position.y + "player" + footpos);

            if (footpos + 0.4f > enemydata.transform.position.y && !enemydata.muteki && !muteki)
            {
                enemydata.hitdamage();
                Jump(jump_force*1.5f);
            }
            else if (!muteki && !enemydata.muteki)
            {
                damaged();
            }
        }

        if (collision.gameObject.CompareTag("obstacle") && muteki==false)
        {
            damaged();
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("ground"))
    //    {
    //        //touch_ground = false;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("death_area"))
        { 
           hp = 0;
            
        }

        if (collision.gameObject.CompareTag("ladder"))
        {
            Isladderrange = true;
            collision.GetComponent<ladder>().SetPlayerInRange = true;

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ladder"))
        {
            Isladderrange = false;
            collision.GetComponent<ladder>().SetPlayerInRange = false;
        }
    }

    public void damaged()
    {
        player_sprite.material.color = new Color32(236, 90, 90, 255);
        hp--;
        muteki = true;
        playeranimator.SetTrigger("hurt");
        StartCoroutine("falsemuteki");
        StartCoroutine("flashing");
        if (hp == 0)
        {
            //Destroy(this.gameObject);
        }
    }

    IEnumerator flashing()
    {
        for (int i = 0; i < mutekitime/(loop_interval*2); i++)
        {
            yield return new WaitForSeconds(loop_interval);
            player_sprite.enabled = false;
            yield return new WaitForSeconds(loop_interval);
            player_sprite.enabled = true;
        }
    }
   

    IEnumerator falsemuteki()
    {

        yield return new WaitForSeconds(mutekitime);
        muteki = false;
        this.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
        Debug.Log("muteki:" + muteki);
    }

  
}
