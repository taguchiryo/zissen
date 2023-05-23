using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class button : MonoBehaviour
{
   // private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        Button testButton = GetComponent<Button>();
        testButton.onClick.AddListener(ButtonClick);
    }

    public void ButtonClick()
    {
        Debug.Log(this.gameObject.name);
        //Debug.Log("click count: " + counter);
        //counter++;
        //foreach (Transform obj in transform)
        //{
        //    var text = obj.GetComponent<TextMeshProUGUI>().text;
        //    Debug.Log(text);
        //}

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
