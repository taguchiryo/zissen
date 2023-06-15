using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gems : MonoBehaviour
{

   public bool check;
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
            if (check)
            {
                SlopeSceneManager._instance.AddGens();
                Destroy(gameObject);
            }
            else
            {
                SceneManagement._instance.AddGens();
                Destroy(this.gameObject);
            }
        }
    }
}
