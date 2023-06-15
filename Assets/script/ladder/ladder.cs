using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    player_movement player;
    bool playerInRang;
    float ladderlange;
    Vector2 Startpos;
    Vector2 Endpos;

    public bool SetPlayerInRange { set { playerInRang = value; } }

    Vector2 laderpos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<player_movement>();
        Startpos = transform.GetChild(0).transform.position;
        Endpos = transform.GetChild(1).transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (playerInRang) {
           
            float tate = Input.GetAxisRaw("Vertical");

            if (player.getIsladderrange && !player.Climb)
            {
                int Climbinput = player.transform.position.y - this.transform.position.y > 0 ? -1 : 1;
                if (tate == Climbinput)
                {
                    player.Climb = true;
                    player.transform.position = Climbinput == -1 ?  Startpos: new Vector2(Endpos.x ,Endpos.y +player.GetCenterfoot);
                    player.freezY();
                    player.ClimbAnimation();

                }

            }


            if (player.Climb && tate != 0)
            {
                //Debug.Log("startpos :" +Startpos + "endpos :" + Endpos);
                Vector2 targetpos = tate > 0 ? Startpos + new Vector2(0, 0.1f) : Endpos - new Vector2(0, 0.1f);

                player.transform.position = Vector2.MoveTowards(player.transform.position, targetpos, 2f * Time.deltaTime);
                player.AnimationSpeed(1);

                if (player.transform.position.y  >= Startpos.y)
                {
                    FinishClimb();
                    player.transform.position = this.transform.position + new Vector3(0,player.GetCenterfoot);
                  
                }
                else if (player.Getfootpos <= Endpos.y)
                {
                    FinishClimb();
                   Vector3 footvec = new Vector2(player.transform.position.x, player.Getfootpos);
                    Vector2 centertofoot = player.transform.position - footvec;
                    player.transform.position = Endpos + centertofoot;
                   
                }
                
            }
            else if (player.Climb && tate == 0)
            {
                player.AnimationSpeed(0);
            }
        }


    }

    void FinishClimb()
    {
        player.Climb = false;
        player.FalsefreezY();
        player.AnimationSpeed(1);
        player.IdleAnimation();


    }

   




}
