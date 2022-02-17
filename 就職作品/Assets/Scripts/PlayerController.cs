using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerStatus))]
[RequireComponent(typeof(MobAttack))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3.0f; // 移動速度
    [SerializeField] private float jumpPower = 3.0f; // ジャンプ力
    [SerializeField] private Animator animator;
    private CharacterController characterController;
    private Transform _transform;
    private Vector3 moveVelocity; // キャラの移動速度情報
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
            // マウスの左クリックで攻撃
            attack.AttackIfPossible();
        }
        // 移動可能な状態ならユーザー入力を移動に反映
        if(status.IsMove)
        {
            moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed; // 横軸移動
            moveVelocity.z = Input.GetAxis("Vertical") * moveSpeed;  // 縦軸移動

            // 移動方向に向く
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
                Debug.Log("ジャンプ");
                moveVelocity.y = jumpPower; // ジャンプさせる
            }
        }
        else 
        {
            moveVelocity.y += Physics.gravity.y * Time.deltaTime; // 重力による加速
        }
        // オブジェクトを動かす
        characterController.Move(moveVelocity * Time.deltaTime);

        // 移動速度をanimatorに反映する
        animator.SetFloat("MoveSpeed", new Vector3(moveVelocity.x, 0, moveVelocity.z).magnitude);
    }
}
