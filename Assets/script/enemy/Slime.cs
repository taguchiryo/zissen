using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Slime : enemy_move
{
    // Start is called before the first frame update
    Animator animtor;
  public  bool move;
   public override void Start()
    {
       
        animtor = GetComponent<Animator>();
        base.Start();
        StartCoroutine("MoveChange");
      
    }

    

    // Update is called once per frame
   public override void Update()
    {
        base.Update();
    }

    public override void Move()
    {
        if (move) {
            transform.position = Vector2.MoveTowards(
                transform.position, target_position,
                speed * Time.deltaTime);
        }

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

    public override void Say()
    {
        Debug.Log("‰´‚ÍƒXƒ‰ƒCƒ€‚¾");
    }

    IEnumerator  MoveChange()
    {
        Debug.Log("move");
        yield return new WaitForSeconds(3);
        
        move = !move;
        animtor.SetBool("move",move);
        StartCoroutine("MoveChange");

    }

   
}
