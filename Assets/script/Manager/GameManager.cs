using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    List<MasterData> maseterdata = new List<MasterData>();
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        LoadMasterData();
        SetMasterData();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadMasterData()
    {
        var textAsset = Resources.Load("MasterData") as TextAsset;
        StringReader reader = new StringReader(textAsset.text);
        //1行ずつに分割

        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            var column = line.Split(',');
           // Debug.Log(column[0] + ": " + column[1] + " :" + column[2] + ":" + column[3]);
            MasterData data = new MasterData
            {
                id = int.Parse(column[0]),
                objname = column[1],
                speed = float.Parse (column[2]),
                jump_force = float.Parse(column[3])
            };
            maseterdata.Add(data);
        }
      
            //各データに分割
           
        
    }

   void  SetMasterData()
    {
        foreach (MasterData data in maseterdata) 
        {
            switch (data.id)
            {
                case 1:
                    player_movement  player =  GameObject.FindGameObjectWithTag("Player").GetComponent<player_movement>();
                    player.speed = data.speed;
                    player.jump_force = data.jump_force;
                    break;

                case 2:
                case 3:
                    GameObject[] enemy = GameObject.FindGameObjectsWithTag("enemy");
                    foreach(GameObject obj in enemy)
                    {
                        var enemy_script = obj.GetComponent<enemy_move>();
                       
                        if (obj.name.Contains(data.objname))
                        {
                            enemy_script.speed = data.speed;
                        }
                    }
                    break;
            }
        }
    }
}

