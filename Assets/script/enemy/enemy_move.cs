using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public abstract class enemy_move : MonoBehaviour
{
    public Transform[] waypoint;
    SpriteRenderer sprite;
    protected List<Vector2> Waypoint = new List<Vector2>();
    protected Vector3 target_position;
    protected int waypoint_number = 0;
    public float speed = 3f;
    protected bool left_direction = true;
    public bool fixedirection;
    float startX;
   protected float scale;
    public int enemy_hp = 2;
    public int mutekitime = 2;
    public float loop_interval = 0.2f;
    public bool muteki = false;
    float headpos { get; set; }
    public float Headpos
    {
        get { return headpos; }
        set { headpos = value; }
    }
    Rigidbody2D rig;
    // Start is called before the first frame update
   public virtual void Start()
    {
        scale = transform.localScale.x;
        startX = transform.position.x;
        for (int i = 0; i < waypoint.Length; i++)
        {
            Vector2 pos = waypoint[i].position; 
            Waypoint.Add(pos);
        }

        target_position = Waypoint[waypoint_number];
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        headpos =   sprite.bounds.size.y/2 + transform.position.y;

    }

    // Update is called once per frame
   public virtual void Update()
    {
        //if (waypoint[0] > transform.position.x)
        //{
        //    rig.AddForce(new Vector2(1, 0) * speed);
        //} else
        //{
        //    rig.velocity = Vector2.zero;
        //}



        //transform.position enemyの現在の座標
        //target_position    enemyのwaypointに格納されている座標
        //移動
        Move();
    }

    public virtual void Move()
    {
        transform.position = Vector2.MoveTowards(
           transform.position, target_position,
           speed * Time.deltaTime);

        if (transform.position == target_position)
        {
            if (fixedirection)
                left_direction = !left_direction;
            if (waypoint_number != Waypoint.Count - 1)
            {
                waypoint_number++;
            }
            else
            {
                waypoint_number = 0;
            }

            target_position = Waypoint[waypoint_number];

            var dir = left_direction ? 1 : -1;
            transform.localScale = scale > 0 ? new Vector2(1 * dir, 1) * scale : new Vector2(1 * dir, -1) * scale;
        }
    }

    public void hitdamage()
    {
        enemy_hp--;
        this.gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
        muteki = true;
        Debug.Log("muteki:" + muteki);
        Debug.Log("enemy_hp:" + enemy_hp);
        if (enemy_hp == 0) { Destroy(gameObject); }
        StartCoroutine("falsemuteki");
        StartCoroutine("flashing");

    }
    public virtual void Say()
    {
        Debug.Log("俺はスライムだ");
    }
    IEnumerator flashing()
    {
        for (int i = 0; i < mutekitime / (loop_interval * 2); i++)
        {
            yield return new WaitForSeconds(loop_interval);
            sprite.enabled = false;
            yield return new WaitForSeconds(loop_interval);
            sprite.enabled = true;
        }
    }

    IEnumerator  falsemuteki()
    {
        
        yield return new WaitForSeconds(2);
        muteki = false;
        this.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
        Debug.Log("muteki:" + muteki);
    }

 

   
}
