using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlayerSlopeMove : MonoBehaviour
{
    public float moveSpeed = 5f; // �ړ����x
    public float slopeSlideSpeed = 10f; // ������鑬�x
    public float maxspeed;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    Vector2 footpos;
    public float jump_force;
    public int hp = 2;
    public bool ground;
   [SerializeField] private ContactFilter2D filter2d = default;
    Vector2 movevec;
    private int SlopeAngle = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        footpos = new Vector2(sprite.bounds.center.x, sprite.bounds.min.y);
    }

    private void FixedUpdate()
    {/*
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // �v���C���[�̍��W���擾���A���̍��W�����݂���^�C���̎�ނ��擾���܂�
        Tilemap tilemap = FindObjectOfType<Tilemap>();
        Vector3Int playerCell = tilemap.WorldToCell(transform.position);
        TileBase tile = tilemap.GetTile(playerCell);

        if (tile != null) // SlopeTile�͎��ۂ̃^�C�����ɍ��킹�ĕύX���Ă�������
        {
            // ������邽�߂ɁA���������̈ړ��ʂɍ�̌X�΂���Z���܂�
            float slopeAngle = tilemap.GetTransformMatrix(playerCell).rotation.eulerAngles.z;
            Vector2 slopeForceDirection = Quaternion.Euler(0f, 0f, slopeAngle) * Vector2.right;
            movement += slopeForceDirection * slopeSlideSpeed;
        }

        */

      
    }
    private void Update()
    {
       ground = rb.IsTouching(filter2d);

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, SlopeAngle));
       // Debug.Log(rb.velocity.magnitude);
        if (ground  && rb.velocity.sqrMagnitude < Mathf.Pow(maxspeed,2))
        {
            movevec = SlopeAngle <= 0 ? transform.right * moveSpeed : transform.right * slopeSlideSpeed;
            rb.AddForce(movevec);
        }

        if(SlopeAngle < 0)   //��яo���Ȃ��悤�ɏd�͂�������
        {
            rb.AddForce(new Vector2(0, -10));
        }

        if (rb.velocity.magnitude == 0)
        {
            rb.AddForce(movevec);
            Debug.Log("movevec :"+ movevec.normalized + "right :" + transform.right);
        }


        if (Input.GetKeyDown(KeyCode.UpArrow) && ground)
        {
            if (SlopeAngle < 0)
            {
                SlopeAngle = 45;
            }
            rb.velocity = new Vector2(10f,0);
           
            rb.AddForce(Vector2.up * jump_force);

        }
        //Debug.Log(rb.velocity.magnitude);
        //if (rb.velocity.sqrMagnitude > Mathf.Sqrt(maxspeed))
        //{
        //    rb.velocity = transform.right * maxspeed;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("death_area"))
        {
            // hp = 0;
            Scene loadScene = SceneManager.GetActiveScene();
            
            SceneManager.LoadScene(loadScene.name);

        }
    }

    public void SetMoveVector(int angle)
    {
        SlopeAngle = angle;
    }
}
