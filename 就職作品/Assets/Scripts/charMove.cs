using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charMove : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float jumpPower;
    private Rigidbody rb; // Rigidbody���g�����߂̕ϐ�
    private bool Ground;  // �n�ʂɂ��Ă邩�̃t���O
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }

        if (Ground == true)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                Ground = false;
                rb.AddForce(Vector3.up * jumpPower);
            }
        }
       
    }
    private void OnCollisionEnter(Collision collision)//  �n�ʂɐG�ꂽ���̏���
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "MoveBlock"||
            collision.gameObject.tag == "RightMove" || collision.gameObject.tag == "LeftMove")// ����Ground�Ƃ����^�O�������I�u�W�F�N�g�ɐG�ꂽ��A
        {
            Ground = true;// �n�ʂɐG�ꂽ���Ƃɂ���
        }
        //if (other.gameObject.tag == "MoveBlock")
        //{
        //    transform.SetParent(other.transform);
        //}
    }

    private void OnCollisionExit(Collision other)
    {
        //if (other.gameObject.tag == "MoveBlock")
        //{
        //    transform.SetParent(null);
        //}
    }
}
