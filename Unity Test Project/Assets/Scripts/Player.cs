using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Champion
{
    Vector3 movePos;
    float moveSpeed = 3.4f;
    bool isMove = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PickingPos();
        Move();
    }

    void PickingPos()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                movePos = hit.point;
                isMove = true;
            }
        }
    }

    void Move()
    {
        if (!isMove) return;

        transform.position = Vector3.MoveTowards(transform.position, movePos, Time.deltaTime * moveSpeed);

        Quaternion direction = Quaternion.LookRotation(movePos - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, direction, Time.deltaTime * 900.0f);

        if (movePos == transform.position)
            isMove = false;
    }
}
