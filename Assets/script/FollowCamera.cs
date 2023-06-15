using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public bool followY;
    public float left = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            if (followY)
                transform.position = new Vector3(target.transform.position.x + left, target.transform.position.y, transform.position.z);
            else
            transform.position = new Vector3(target.transform.position.x + left, transform.position.y, transform.position.z);
        }
        
    }
}
