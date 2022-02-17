using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobStatus))]
public class MobAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f; // 攻撃後クールダウン
    [SerializeField] private Collider attackCollider;
    [SerializeField] private AudioSource swingSound;

    private MobStatus status;

    // Start is called before the first frame update
    private void Start()
    {
        status = GetComponent<MobStatus>();
    }

    // 攻撃可能なら攻撃
    public void AttackIfPossible()
    {
        if (!status.IsAttack) return;
        // ステータスと衝突したオブジェクトで攻撃可否を判断する
        status.GoAttackStateIfPossible();
    }
    // 攻撃対象が範囲に入ったら呼ばれる
    public void AttackRangeEnter(Collider collider)
    {
        AttackIfPossible();
    }

    // 攻撃開始時に呼ばれる
    public void OnAttackStart()
    {
        attackCollider.enabled = true;
        if(swingSound != null)
        {
            // 武器を振るときの音再生。pitch(再生速度)ランダムに変化させて
            // 少し違う音が出るように
            swingSound.pitch = Random.Range(0.7f, 1.3f);
            swingSound.Play();
        }
    }
    // attackColliderが攻撃対象にHITしたときに呼ばれる
    public void OnHitAttack(Collider collider)
    {
        var targetMob = collider.GetComponent<MobStatus>();
        if (null == targetMob) return;

        // プレイヤーにダメージ与える
        targetMob.Damage(1);
    }
    // 攻撃終了時呼ばれる
    public void OnAttackFinished()
    {
        attackCollider.enabled = false;
        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        status.GoNormalStateIfPossible();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
