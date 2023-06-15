using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Crank_start : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase tilebase;
    public Sprite crank_down;
    public KeyCode actionKey = KeyCode.Space;
    bool playerInRang;

    public Vector2Int startpos;
    public Vector2Int endpos;

    private SpriteRenderer spriterender;
    // Start is called before the first frame update
    void Start()
    {
        spriterender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRang && Input.GetKeyDown(actionKey))
        {
            spriterender.sprite = crank_down;
           StartCoroutine("SetTile");
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRang = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRang = false;
        }
    }

    private IEnumerator SetTile()
    {
        for (int i = 0; i < endpos.x - startpos.x; i++)
        {
            yield return new WaitForSeconds(0.2f);
            tilemap.SetTile(new Vector3Int(startpos.x + i, startpos.y, 0), tilebase);
        }


    }

    
}
