using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slope : MonoBehaviour
{
    public float slideSpeed = 5f; // 滑る速度
    private bool isSliding = false; // 滑っているかどうかのフラグ
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
