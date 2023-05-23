using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Getgems : MonoBehaviour
{
    public TextMeshProUGUI gem_TMP;
    // Start is called before the first frame update
    void Awake()
    {
        getgem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void getgem()
    {
        int gem_num = SceneManagement._instance.Getgems();
        gem_TMP.text += gem_num.ToString();
        Debug.Log(gem_TMP.text);
    }
}
