using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocity : MonoBehaviour
{
    Rigidbody2D vel;
    // Start is called before the first frame update
    void Start()
    {

        vel = this.gameObject.GetComponent<Rigidbody2D>();
        //var n = 0;
        Debug.Log("デバッグ");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("アップデートデバッグ");
        //Time.deltaTime
        //transform.position += new Vector3(0.1f, -0.1f, 0);
        Debug.Log(Time.deltaTime);

        //右に力をかける
        vel.AddForce(new Vector3(1, -1, 0), ForceMode2D.Impulse);

        //右に移動(小さいワープしてるみたいな)
        //vel.velocity = new Vector3(1, -1, 0);


        //if (Input.GetKey("right"))
        //{
        //    var migi = this.gameObject.GetComponent<Rigidbody2D>();
        //    migi.velocity = new Vector3(10.0f, 0, 0);
        //}

        //if (Input.GetKey("left"))
        //{
        //    var migi = this.gameObject.GetComponent<Rigidbody2D>();
        //    migi.velocity = new Vector3(-10.0f, 0, 0);
        //}

        //if (Input.GetKey("up"))
        //{
        //    var migi = this.gameObject.GetComponent<Rigidbody2D>();
        //    migi.velocity = new Vector3(0, 10.0f, 0);
        //}

        //if (Input.GetKey("down"))
        //{
        //    var migi = this.gameObject.GetComponent<Rigidbody2D>();
        //    migi.velocity = new Vector3(0, -10.0f, 0);
        //}

    }
}
