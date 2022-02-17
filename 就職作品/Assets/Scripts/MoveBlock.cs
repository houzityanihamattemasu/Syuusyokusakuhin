using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    private Rigidbody rb; // RigidbodyÇégÇ§ÇΩÇﬂÇÃïœêî
    private Vector3 defalutPos;
    private Vector3 MoveX;
    private Vector3 MoveY;
    private Vector3 MoveZ;
    int counter = 0;
    float move = 0.01f; // à⁄ìÆó 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defalutPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.MovePosition(new Vector3(defalutPos.x, defalutPos.y, defalutPos.z + Mathf.PingPong(Time.time, 2)));
        if(gameObject.tag == "MoveBlock")
        {
            MoveZ = new Vector3(0, 0, move);
            transform.Translate(MoveZ);
            counter++;

            if (counter == 300)
            {
                counter = 0;
                move *= -1;
            }
        }
        else if(gameObject.tag == "RightMove")
        {
            MoveX = new Vector3(move, 0, 0);
            transform.Translate(MoveX);
            counter++;

            if (counter == 600)
            {
                counter = 0;
                move *= -1;
            }
        }
        else if (gameObject.tag == "LeftMove")
        {
            MoveX = new Vector3(-move, 0, 0);
            transform.Translate(MoveX);
            counter++;

            if (counter == 600)
            {
                counter = 0;
                move *= -1;
            }
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(this.transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
