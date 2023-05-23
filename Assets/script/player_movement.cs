using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{
    public float speed = 10f;
    public float maxspeed = 10f;
    public float jump_force = 500;
    Rigidbody2D player;
    SpriteRenderer player_sprite;
    Animator playeranimator;
    public int hp = 2;
    public int mutekitime = 2;
    public float loop_interval = 0.2f;
    bool muteki = false;
    float footpos;
    //public bool touch_ground = true;
    float scale;
    [SerializeField] private ContactFilter2D filter2d = default;
    

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject.GetComponent<Rigidbody2D>();
        player_sprite = this.gameObject.GetComponent<SpriteRenderer>();
        playeranimator = GetComponent<Animator>();
        scale = transform.localScale.y;
        Debug.Log(footpos);
        //var text = Resources.Load("Hello") as TextAsset;
        // Debug.Log(text);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        bool ground = player.IsTouching(filter2d);
        playeranimator.SetBool("is_ground",ground);
        float yoko = Input.GetAxisRaw("Horizontal");
        if (ground && yoko == 0)
        {
            player.velocity = new Vector2(0, player.velocity.y);
            
        }

        if (ground)
        {
            player.AddForce(new Vector2(yoko, 0) * speed*Time.deltaTime*1000);
        } else
        {
            player.AddForce(new Vector2(yoko, 0) * speed*0.1f*Time.deltaTime*1000);
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
       

        if (Input.GetKeyDown(KeyCode.UpArrow) && ground)
        {
             Debug.Log("Jump");
            playeranimator.SetTrigger("jump");
            player.AddForce(new Vector2(0, 1) * jump_force);
            
        }
      
        if (Mathf.Abs(player.velocity.x) > maxspeed)
        {
            player.velocity = player.velocity.x >= 0 ? new Vector2(maxspeed, player.velocity.y) : new Vector2(-maxspeed, player.velocity.y);
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
           //ß touch_ground = true;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("enemy"))
        {
            var enemydata = collision.gameObject.GetComponent<enemy_move>();
            footpos = player_sprite.bounds.min.y;

           
            if (footpos  > enemydata.Headpos && !enemydata.muteki && !muteki)
                enemydata.hitdamage();
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
