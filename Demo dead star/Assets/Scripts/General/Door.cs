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
        
    }

    public void MoveDoor(bool whatDo)
    {
        if (whatDo)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }
    
    void OpenDoor()
    {
        if (leftDoor)
        {
            if (axesX)
            {
                Vector3 targetPos = new Vector3(startPosition.x - moveDistanse, startPosition.y, startPosition.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            }
            else
            {
                Vector3 targetPos = new Vector3(startPosition.x, startPosition.y, startPosition.z - moveDistanse);
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            }
        }
        else
        {
            if (axesX)
            {
                Vector3 targetPos = new Vector3(startPosition.x + moveDistanse, startPosition.y, startPosition.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            }
            else
            {
                Vector3 targetPos = new Vector3(startPosition.x, startPosition.y, startPosition.z + moveDistanse);
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            }
        }
    }

    void CloseDoor()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
    }
}
