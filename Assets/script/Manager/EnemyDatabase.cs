using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyDatabase", menuName = "MyScriptable/Enemy Database")]
public class EnemyDatabase : ScriptableObject
{
    public List<enemy> enemyClasses;

    public List<enemy> GetEnemyClassByIDs(int[] ids)
    {
        List<enemy> enemies = new List<enemy>();
        foreach (int id in ids) {
            enemies.Add(enemyClasses.Find(enemyClass => enemyClass.id == id));
        }
        return enemies;
    }

}
