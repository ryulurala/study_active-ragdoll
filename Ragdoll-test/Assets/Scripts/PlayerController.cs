using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float playerSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        move();
    }

    private void move()
    {
        Vector3 directionVector3 = Vector3.zero;    // 방향 벡터

        if (Input.GetKey(KeyCode.UpArrow))      // ↑
        {
            directionVector3 += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow))    // ↓
        {
            directionVector3 += Vector3.back;
        }
        if (Input.GetKey(KeyCode.RightArrow))   // →
        {
            directionVector3 += Vector3.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))    // ←
        {
            directionVector3 += Vector3.left;
        }

        if (directionVector3.magnitude != 0)
        {
            // 방향을 바라보게 함. (by using. 벡터 정규화)
            transform.rotation = Quaternion.LookRotation(directionVector3.normalized);

            // 캐릭터는 앞으로만 가도록 한다.
            // 방향 벡터의 크기(magnitude)만큼 움직인다.
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }
    }
}
