using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravitypoint : MonoBehaviour
{
    public int gravity;

    Rigidbody2D playerrig;
    player_movement player_script;
    // Start is called before the first frame update
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerrig = player.GetComponent<Rigidbody2D>();
        player_script = player.GetComponent<player_movement>();
        Debug.Log(playerrig);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        Debug.Log("hit");
        playerrig.gravityScale = gravity;
        player_script.jump_force = 8000;
    }
}
