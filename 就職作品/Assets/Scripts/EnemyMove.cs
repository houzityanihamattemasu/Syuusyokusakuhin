using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyStatus))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField] private LayerMask raycastLayerMask;
    private NavMeshAgent agent;
    private RaycastHit[] raycastHits = new RaycastHit[10];
    private EnemyStatus status;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        status = GetComponent<EnemyStatus>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    // �v���C���[�ڎw���Đi��
    //    //agent.destination = playerController.transform.position;
    //}
    public void OnDetectObject(Collider collider)
    {
        if(!status.IsMove)
        {
            agent.isStopped = true;
            return;
        }
        // �v���C���[�^�O�����Ȃ�΂��̃I�u�W�F�N�g��ǂ�������
        if(collider.CompareTag("Player"))
        {
            // �����ƃv���C���[�̍��W�̍����v�Z����
            var positionDiff = collider.transform.position - transform.position;
            var distance = positionDiff.magnitude;// �v���C���[�Ƃ̋������v�Z����
            var direction = positionDiff.normalized;// �v���C���[�ւ̕���

            // raycastHits�Ƀq�b�g����Collider����W���Ȃǂ��i�[�����
            var hitCount = Physics.RaycastNonAlloc(transform.position, direction, raycastHits, distance,raycastLayerMask);
            //Debug.Log("hitCount:" + hitCount);
            if(hitCount == 0)
            {
                // �v���C���[�ɂ�CharacterController�g���Ă���Collider�͎g���Ă��Ȃ��̂�RayCast�̓q�b�g���Ȃ��B
                // �q�b�g����0�Ȃ�v���C���[�Ƃ̊Ԃɏ�Q���͂Ȃ����ƂɂȂ�B
                agent.isStopped = false;
                agent.destination = collider.transform.position;
            }
            else
            {
                // �����������~
                agent.isStopped = true;
            }
            agent.destination = collider.transform.position;
        }
    }
}
