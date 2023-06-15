using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new EnemyData",menuName = "MyScriptable/Enemy Data")]
public class enemy: ScriptableObject
{
    public int id;
    public string enemyName;
    public enemy_move scriptType; // = Activator.CreateInstance(Type.GetType("myClass"));
    [SerializeField] private Sprite icon;
    // Start is called before the first frame update

   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
