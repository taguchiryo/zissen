using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class foot_hit : MonoBehaviour
{
    player_movement player_script;
    // Start is called before the first frame update
    void Start()
    {
        player_script = transform.root.gameObject.GetComponent<player_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
          //  player_script.set_jump(false);
            
        }
    }

   
}
