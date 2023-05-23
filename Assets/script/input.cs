using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            Debug.Log("左");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("2が押されました");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("3が押されました");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("4が押されました");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("5が押されました");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Debug.Log("6が押されました");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Debug.Log("7が押されました");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log("8が押されました");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Debug.Log("9が押されました");
        }
        

        float yoko = Input.GetAxisRaw("Horizontal");
        Debug.Log(yoko);

        float tate = Input.GetAxis("Vertical");
        Debug.Log(tate);
    }
}
