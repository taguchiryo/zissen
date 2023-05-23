using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    
    public GameObject time_object = null;
    
    // Start is called before the first frame update
    void Start()
    {
        Text time_text = time_object.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Text time_text = time_object.GetComponent<Text>();
        time_text.text = "000";
    }
}
