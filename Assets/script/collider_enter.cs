using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_enter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    
    //    Debug.Log(collision.gameObject.name);
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    Debug.Log("exit: " + collision.gameObject.name);
    //}

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    Debug.Log("stay: " + collision.gameObject.name);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("triger enter: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("death_area")){
            Debug.Log("game over");
        }
    }
}
