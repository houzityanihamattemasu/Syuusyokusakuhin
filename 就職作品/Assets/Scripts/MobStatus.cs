using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MobStatus : MonoBehaviour
{
    protected enum StateEnum
    {
        Normal, // 通常
        Attack, // 攻撃
        Die     // 死亡
    }
    // 移動可能かどうか
    public bool IsMove => StateEnum.Normal == state;
    // 攻撃可能かどうか
    public bool IsAttack => StateEnum.Normal == state;

    // 体力最大値を返す
    public float LifeMax => lifeMax;

    // 体力の値を返す
    public float Life => life;

    [SerializeField] private float lifeMax = 10; // 体力の最大値
    [SerializeField] protected Animator animator; // シリアライズしなかったら攻撃できなかったので無理やり
    protected StateEnum state = StateEnum.Normal; // Mobの状態
    private float life; // 今の体力

    // Start is called before the first frame update
    protected virtual void Start()
    {
        life = lifeMax;
        animator = GetComponent<Animator>();
    }

    // キャラが倒れた時の処理
    protected virtual void OnDie()
    {

    }

    // ダメージ受ける
    public void Damage(int damage)
    {
        if (state == StateEnum.Die)
        {
            return;
        }
        life -= damage;
        if (life > 0) 
            return;

        state = StateEnum.Die;
        animator.SetTrigger("Die");
        OnDie();
    }

    // 可能なら攻撃中状態に遷移
    public void GoAttackStateIfPossible()
    {
        if (!IsAttack) return;

        state = StateEnum.Attack;
        animator.SetTrigger("Attack");
        
    }

    // 可能ならNormalに遷移
    public void GoNormalStateIfPossible()
    {
        if (state == StateEnum.Die) return;
        state = StateEnum.Normal;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
