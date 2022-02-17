using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobStatus))]
public class MobAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 0.5f; // �U����N�[���_�E��
    [SerializeField] private Collider attackCollider;
    [SerializeField] private AudioSource swingSound;

    private MobStatus status;

    // Start is called before the first frame update
    private void Start()
    {
        status = GetComponent<MobStatus>();
    }

    // �U���\�Ȃ�U��
    public void AttackIfPossible()
    {
        if (!status.IsAttack) return;
        // �X�e�[�^�X�ƏՓ˂����I�u�W�F�N�g�ōU���ۂ𔻒f����
        status.GoAttackStateIfPossible();
    }
    // �U���Ώۂ��͈͂ɓ�������Ă΂��
    public void AttackRangeEnter(Collider collider)
    {
        AttackIfPossible();
    }

    // �U���J�n���ɌĂ΂��
    public void OnAttackStart()
    {
        attackCollider.enabled = true;
        if(swingSound != null)
        {
            // �����U��Ƃ��̉��Đ��Bpitch(�Đ����x)�����_���ɕω�������
            // �����Ⴄ�����o��悤��
            swingSound.pitch = Random.Range(0.7f, 1.3f);
            swingSound.Play();
        }
    }
    // attackCollider���U���Ώۂ�HIT�����Ƃ��ɌĂ΂��
    public void OnHitAttack(Collider collider)
    {
        var targetMob = collider.GetComponent<MobStatus>();
        if (null == targetMob) return;

        // �v���C���[�Ƀ_���[�W�^����
        targetMob.Damage(1);
    }
    // �U���I�����Ă΂��
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
