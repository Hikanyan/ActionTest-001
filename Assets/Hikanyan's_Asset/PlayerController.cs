using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

   

    [SerializeField] float speed = 6.0f;          //���s���x
    [SerializeField] float jumpSpeed = 8.0f;      //�W�����v��
    [SerializeField] float gravity = 20.0f;       //�d�͂̑傫��
    [SerializeField] float rotateSpeed = 5.0f;    //��]���x
    [SerializeField] float camRotSpeed = 5.0f;    //���_�̏㉺�X�s�[�h

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float h, v;
    private float mX, mY;
    private float lookUpAngle;
    private float flyingTime = 0f;
    private bool isFlying;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        Debug.Log(jumpSpeed);

        h = Input.GetAxis("Horizontal");    //���E�̖��L�[�̒l���擾(-1.0~1.0)
        v = Input.GetAxis("Vertical");      //�㉺�̖��L�[�̒l���擾(-1.0~1.0)
        mX = Input.GetAxis("Mouse X");      //�}�E�X�̍��E�ړ���(-1.0~1.0)
        mY = Input.GetAxis("Mouse Y");      //�}�E�X�̏㉺�ړ���(-1.0~1.0)


        Camera.main.transform.Rotate(new Vector3(camRotSpeed * mY, 0, 0));

        if (controller.isGrounded || isFlying)
        {
            moveDirection = new Vector3(h, 0, v);
            moveDirection = transform.TransformDirection(moveDirection);
            gameObject.transform.Rotate(new Vector3(0, rotateSpeed * mX, 0));
        }

        if (controller.isGrounded)
        {
            isFlying = false;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
                flyingTime = 0f;
            }
        }
        else
        {
            flyingTime += Time.deltaTime;
            if (Input.GetButtonDown("Jump"))
            {
                if (flyingTime < 0.35f)
                    isFlying = !isFlying;
                else
                    flyingTime = 0f;
            }
        }

        if (isFlying)
            moveDirection.y = Input.GetButton("Jump") ? 0.8f * jumpSpeed : 0f;
        else
            moveDirection.y -= gravity * Time.deltaTime;    //�d�͂̌���
        controller.Move(moveDirection * Time.deltaTime);    //�L�����N�^�[���ړ�������

    }
    internal void JumpUp(float jumpUpSpeed)
    {
        jumpSpeed += jumpUpSpeed;
    }

}