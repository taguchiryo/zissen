using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.SceneManagement;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static StageManager Instance;
    public List<Stage> Stages;
    public int currentstage = 0;
    public EnemyDatabase enemydatabases;
    private const　string filepass = "";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        LoadCsv();
    }
    void Start()
    {
        for (int i = 0; i < Stages.Count; i++)
        {
            Debug.Log("ステージ" + (i + 1));
            Debug.Log("敵の数" + Stages[i].num_enemies);
            Stages[i].enemies.ForEach(enemy =>
            {
                enemy.scriptType = (enemy_move)Activator.CreateInstance(Type.GetType(enemy.enemyName));
                Type componentType = Type.GetType(enemy.enemyName);
                gameObject.AddComponent(componentType);

                enemy.scriptType.Say();
                Debug.Log(" id: " + enemy.id + " name: " + enemy.enemyName + " Class: " + enemy.scriptType.GetType());
            });
                }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadCsv()
    {
        var textAsset = Resources.Load("StageData") as TextAsset;
        StringReader reader = new StringReader(textAsset.text);
        //1行ずつに分割
        bool isFirstLine = true;
        while (reader.Peek() != -1)
        {
            string line = reader.ReadLine();
            if (isFirstLine) { isFirstLine = false; continue; }
           
            var column = line.Split(',');
            // Debug.Log(column[0] + ": " + column[1] + " :" + column[2] + ":" + column[3]);
            var stagenum = column[0];
            var stagenum_index = int.Parse(stagenum.Split('-')[1]);
            var ids = column[2].Split(':').Select(int.Parse).ToArray();
            var enemyclass = enemydatabases.GetEnemyClassByIDs(ids);

           
            Stages.Add(new Stage
            {
                num_enemies = int.Parse(column[1]),
                enemies = enemyclass
            });

        }
    }
}
