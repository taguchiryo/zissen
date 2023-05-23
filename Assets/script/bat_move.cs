using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bat_move : MonoBehaviour
{
  public  bool is_move = false;
    bool x_move = false;
    Rigidbody2D bat;
    Vector3 flypoint;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        bat = this.gameObject.GetComponent<Rigidbody2D>();
        flypoint = new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (is_move)
        {
            if (!x_move) {
                if (flypoint == transform.position)
                {
                    x_move = true;
                    animator.SetBool("x_move", true);
                }
                    transform.position = Vector2.MoveTowards(transform.position, flypoint, 0.02f);
            }
            else
            {
                bat.velocity = new Vector2(-10,0);
            }
           
        }

    }

    public void set_is_move(bool bol)
    {
        is_move = bol;
    }

}
