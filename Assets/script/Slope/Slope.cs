using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slope : MonoBehaviour
{
    public float slideSpeed = 5f; // ���鑬�x
    private bool isSliding = false; // �����Ă��邩�ǂ����̃t���O
    public int SlopeAngle;

    PlayerSlopeMove playerscript;
    private void Start()
    {
        playerscript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSlopeMove>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerscript.SetMoveVector(SlopeAngle);

    }



}
