using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goal : MonoBehaviour
{
    public
   
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
            Destroy(collision.gameObject);
            Scene stage = SceneManager.GetActiveScene();

            
            SceneManager.LoadScene("ClearMessage", LoadSceneMode.Additive);
           
            StartCoroutine("nextStage");
            
        }
    }

    IEnumerator nextStage()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Stage 2");
    }

}
