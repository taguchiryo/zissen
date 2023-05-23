using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_pra : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        string scene_name = SceneManager.GetActiveScene().name;
        //Debug.Log(SceneManager.GetActiveScene().name);
        SceneManager.UnloadSceneAsync(scene_name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
