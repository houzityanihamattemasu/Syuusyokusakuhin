using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MobStatus : MonoBehaviour
{
    protected enum StateEnum
    {
        Normal, // �ʏ�
        Attack, // �U��
        Die     // ���S
    }
    // �ړ��\���ǂ���
    public bool IsMove => StateEnum.Normal == state;
    // �U���\���ǂ���
    public bool IsAttack => StateEnum.Normal == state;

    // �̗͍ő�l��Ԃ�
    public float LifeMax => lifeMax;

    // �̗͂̒l��Ԃ�
    public float Life => life;

    [SerializeField] private float lifeMax = 10; // �̗͂̍ő�l
    [SerializeField] protected Animator animator; // �V���A���C�Y���Ȃ�������U���ł��Ȃ������̂Ŗ������
    protected StateEnum state = StateEnum.Normal; // Mob�̏��
    private float life; // ���̗̑�

    // Start is called before the first frame update
    protected virtual void Start()
    {
        life = lifeMax;
        animator = GetComponent<Animator>();
    }

    // �L�������|�ꂽ���̏���
    protected virtual void OnDie()
    {

    }

    // �_���[�W�󂯂�
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

    // �\�Ȃ�U������ԂɑJ��
    public void GoAttackStateIfPossible()
    {
        if (!IsAttack) return;

        state = StateEnum.Attack;
        animator.SetTrigger("Attack");
        
    }

    // �\�Ȃ�Normal�ɑJ��
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
