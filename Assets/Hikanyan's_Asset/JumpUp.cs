using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUp : ItemBase
{
    [SerializeField] private float jumpSpeed = 50f;
    public override void Activate()
    {
        FindObjectOfType<PlayerController>().JumpUp(jumpSpeed);
    }
}
