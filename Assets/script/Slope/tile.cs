using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class tile : MonoBehaviour
{

    Tilemap tilemap;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach(ContactPoint2D contactpoint in collision.contacts)
            {
                Vector3Int tileposition = tilemap.WorldToCell(contactpoint.point);
                Vector3 tileworld = tilemap.GetCellCenterWorld(tileposition);

                Debug.Log(tileworld + ": "+ tileposition);
                //Debug.Log("contact:"+ contactpoint.point + "Player" + player.transform.position);
            }
        }
    }
}
