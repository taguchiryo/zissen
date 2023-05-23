using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public void hp1()
    {
        SceneManagement._instance.Sethp(1);
    }

    public void SetGoal()
    {
        SceneManagement._instance.Move_to_Goal();
    }
}
