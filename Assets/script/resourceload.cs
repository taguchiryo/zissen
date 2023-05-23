using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class resourceload : MonoBehaviour
{
    // Start is called before the first frame update
    List<string[]> csvDatas = new List<string[]>();
    void Start()
    {
      var  player_sprite = this.gameObject.GetComponent<SpriteRenderer>();
       var scale = transform.localScale.y;
        //var text = Resources.Load("Hello") as TextAsset;
        // Debug.Log(text);
        var sprite = Resources.Load<Sprite>("gazou");
        var sprite1 = Resources.Load("gazou") as Sprite;
        Debug.Log(sprite);
        player_sprite.sprite = sprite;

        var textAsset = Resources.Load("test") as TextAsset;
        StringReader reader = new StringReader(textAsset.text);
        
       // Debug.Log(reader);
        while(reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            csvDatas.Add(line.Split(','));
           
        }
    
        for (int i = 0; i < csvDatas.Count; i++)
        {
            Debug.Log("id:" + csvDatas[i][0] + ",  ATP:" + csvDatas[i][1]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
