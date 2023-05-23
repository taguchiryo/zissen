using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensor : MonoBehaviour
{
    public bat_move bat_script_1;
    public bat_move bat_script_2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           Debug.Log("sensor");
           bat_script_1.set_is_move(true);
           bat_script_2.set_is_move(true);
        }
    }
}
