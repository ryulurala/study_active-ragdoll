using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float walkSpeed = 3.0f;
    private float runSpeed = 6.0f;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        move();
    }

    private void move()
    {
        Vector3 directionVector3 = Vector3.zero;    // 방향 벡터
        float moveSpeed = 0.0f;

        if (Input.GetKey(KeyCode.UpArrow))      // ↑
        {
            directionVector3 += Vector3.forward;
            moveSpeed = walkSpeed;
        }
        if (Input.GetKey(KeyCode.DownArrow))    // ↓
        {
            directionVector3 += Vector3.back;
            moveSpeed = walkSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))   // →
        {
            directionVector3 += Vector3.right;
            moveSpeed = walkSpeed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))    // ←
        {
            directionVector3 += Vector3.left;
            moveSpeed = walkSpeed;
        }

        if (moveSpeed != 0.0f)      // 움직인다면
        {
            if (directionVector3 != Vector3.zero)
            {
                // 방향을 바라보게 함. (by using. 벡터 정규화)
                transform.rotation = Quaternion.LookRotation(directionVector3.normalized);
            }

            if (Input.GetKey(KeyCode.E))
            {
                // 뛰기
                moveSpeed = runSpeed;
            }
        }

        // Animation 제어
        animator.SetBool("IsMoving", moveSpeed != 0);   // 움직임
        animator.SetBool("IsRunning", moveSpeed == runSpeed);   // 뛰기

        // 캐릭터는 앞으로만 가도록 한다.
        // 방향 벡터의 크기(magnitude)만큼 움직인다.
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
