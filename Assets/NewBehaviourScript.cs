using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      foreach(Rigidbody2D rig in GetComponentsInChildren<Rigidbody2D>())
        {
            Debug.Log(rig.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
