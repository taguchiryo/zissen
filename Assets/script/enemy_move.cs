using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class enemy_move : MonoBehaviour
{
    public Vector3[] waypoint;
    private Vector3 target_position;
    private int waypoint_number = 0;
    private float speed = 3f;
    bool left_direction = true;
    float scale;
    public int enemy_hp = 2;
    public bool muteki = false;
    float headpos { get; set; }
    public float Headpos
    {
        get { return headpos; }
        set { headpos = value; }
    }
    Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale.y;
        target_position = waypoint[waypoint_number];
        rig = GetComponent<Rigidbody2D>();
        headpos = GetComponent<SpriteRenderer>().bounds.max.y;

    }

    // Update is called once per frame
    void Update()
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
        transform.position = Vector2.MoveTowards(
            transform.position, target_position,
            speed * Time.deltaTime);

        if (transform.position == target_position)
        {
            left_direction = !left_direction;
            if (waypoint_number != waypoint.Length - 1)
            {
                waypoint_number++;
            } else
            {
                waypoint_number = 0;
            }
            
            target_position = waypoint[waypoint_number];

            var dir = left_direction ? -1 : 1;
            transform.localScale = new Vector3(1 * dir,1,1)*scale;
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

    }

    IEnumerator  falsemuteki()
    {
        
        yield return new WaitForSeconds(2);
        muteki = false;
        this.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
        Debug.Log("muteki:" + muteki);
    }
}
