using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement _instance;
    //public static singleton instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {
    //            _instance = new singleton();
    //        }
    //        return _instance;
    //    }
    //}

    //player_scriptのなかにGameObjectが入ってる
    player_movement player_script;

    public GameObject player;
    bool isrestart = false;
    private int gem_count = 0;
    private int hp;
    public Transform goal_position;
   


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        player_script = player.GetComponent<player_movement>();
        hp = player_script.hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            hp = player_script.hp;
        }
        if (hp <= 0 && !isrestart)
        {
            Destroy(player.gameObject);
            Debug.Log("player : "　+ hp);
            isrestart = true;
            StartCoroutine("restart");
            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        }
    }

    public void AddGens()
    {
        gem_count++;
        Debug.Log("gem_count :" + gem_count);
    }
    public int Getgems()
    {
        return gem_count;
    }

    public void Sethp(int hp)
    {
        player_script.hp = hp;
    }

    public void Move_to_Goal()
    {
        player_script.transform.position = goal_position.position;
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Stage 1");
    }
}
