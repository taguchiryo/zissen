using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviour : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.gameObject.name);
        var rigid =
        this.gameObject.GetComponent<Rigidbody2D>();
        rigid.simulated = false;

        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        obj.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
