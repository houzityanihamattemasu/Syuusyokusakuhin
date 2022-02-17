using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerStatus))]
[RequireComponent(typeof(MobAttack))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f; // �ړ����x
    [SerializeField] private float jumpPower = 3.0f; // �W�����v��
    [SerializeField] private Animator animator;
    private CharacterController characterController;
    private Transform _transform;
    private Vector3 moveVelocity; // �L�����̈ړ����x���
    private PlayerStatus status;
    private MobAttack attack;
    // Start is called before the first frame update
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        _transform = transform;
        status = GetComponent<PlayerStatus>();
        attack = GetComponent<MobAttack>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            // �}�E�X�̍��N���b�N�ōU��
            attack.AttackIfPossible();
        }
        // �ړ��\�ȏ�ԂȂ烆�[�U�[���͂��ړ��ɔ��f
        if(status.IsMove)
        {
            moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed; // �����ړ�
            moveVelocity.z = Input.GetAxis("Vertical") * moveSpeed;  // �c���ړ�

            // �ړ������Ɍ���
            _transform.LookAt(_transform.position + new Vector3(moveVelocity.x, 0, moveVelocity.z));
        }
        else
        {
            moveVelocity.x = 0;
            moveVelocity.z = 0;
        }
        
        if(characterController.isGrounded)
        {
            if(Input.GetButtonDown("Jump"))
            {
                Debug.Log("�W�����v");
                moveVelocity.y = jumpPower; // �W�����v������
            }
        }
        else 
        {
            moveVelocity.y += Physics.gravity.y * Time.deltaTime; // �d�͂ɂ�����
        }
        // �I�u�W�F�N�g�𓮂���
        characterController.Move(moveVelocity * Time.deltaTime);

        // �ړ����x��animator�ɔ��f����
        animator.SetFloat("MoveSpeed", new Vector3(moveVelocity.x, 0, moveVelocity.z).magnitude);
    }
}
