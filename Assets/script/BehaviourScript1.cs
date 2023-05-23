using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourScript1 : MonoBehaviour
{
    bool log = true;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("スタートログ");
        this.gameObject.SetActive(false);
        var co
           = this.gameObject.GetComponent<BoxCollider2D>();
        co.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (log)
        {
            Debug.Log("アップデートログ");
            log = false;
        } 
        
    }

    private void OnEnable()
    {
        Debug.LogWarning("OnEnable Warning");
    }

    private void OnDisable()
    {
        Debug.LogWarning("OnDisable Warning");
        //Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        Debug.LogError("Destroy Error");
    }
}
