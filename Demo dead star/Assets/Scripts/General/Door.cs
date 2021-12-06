using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float moveDistanse = 1.54f;
    public bool axesX; //если тру то x, если нет то z
    public bool leftDoor; //тру если левая дверь, фолс если левая
    Vector3 startPosition;

    public float speed = 2f;

    bool doorAlreadyOpen = false;
    Vector3 targetPos;
    static int a = 0;
    static int b = 0;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

        if (transform.rotation.z == 0) 
        {
            axesX = true;
        }
        else
        {
            axesX = false;
        }


        leftDoor = transform.CompareTag("LeftDoor");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(a + " + "+ b);
    }

    public void MoveDoor(bool whatDo)
    {
        if (whatDo /*&& !doorAlreadyOpen*/)
        {
            if (!doorAlreadyOpen) 
            OpenDoor();
        }
        else 
        {
            if(doorAlreadyOpen)
            CloseDoor();
        }
    }
    void XLeftDoor()
    {
        targetPos = new Vector3(startPosition.x - moveDistanse, startPosition.y, startPosition.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        proverka();
    }

    void ZLeftDoor()
    {
        targetPos = new Vector3(startPosition.x, startPosition.y, startPosition.z - moveDistanse);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        proverka();
    }
    void XRightDoor()
    {
        targetPos = new Vector3(startPosition.x + moveDistanse, startPosition.y, startPosition.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        proverka();
    }

    void ZRightDoor()
    {
        targetPos = new Vector3(startPosition.x, startPosition.y, startPosition.z + moveDistanse);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        proverka();
    }
    void OpenDoor()
    {
        if (leftDoor)
        {
            if (axesX)
            {
                XLeftDoor();
            }
            else
            {
                ZLeftDoor();
            }
        }
        else
        {
            if (axesX)
            {
                XRightDoor();
            }
            else
            {
                ZRightDoor();
            }
        }
        a++;
    }

    void proverka()
    {
        if (transform.position == targetPos)
        {
            doorAlreadyOpen = true;
        }
    }

    void CloseDoor()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        if (transform.position == startPosition)
        {
            doorAlreadyOpen = false;
        }
        //else
        //{
        //    CloseDoor();
        //}
        b++;
    }
}
