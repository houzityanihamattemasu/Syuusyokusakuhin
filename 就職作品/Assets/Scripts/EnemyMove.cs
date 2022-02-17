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
    //    // プレイヤー目指して進む
    //    //agent.destination = playerController.transform.position;
    //}
    public void OnDetectObject(Collider collider)
    {
        if(!status.IsMove)
        {
            agent.isStopped = true;
            return;
        }
        // プレイヤータグ持ちならばそのオブジェクトを追いかける
        if(collider.CompareTag("Player"))
        {
            // 自分とプレイヤーの座標の差を計算する
            var positionDiff = collider.transform.position - transform.position;
            var distance = positionDiff.magnitude;// プレイヤーとの距離を計算する
            var direction = positionDiff.normalized;// プレイヤーへの方向

            // raycastHitsにヒットしたColliderや座標情報などが格納される
            var hitCount = Physics.RaycastNonAlloc(transform.position, direction, raycastHits, distance,raycastLayerMask);
            //Debug.Log("hitCount:" + hitCount);
            if(hitCount == 0)
            {
                // プレイヤーにはCharacterController使っていてColliderは使っていないのでRayCastはヒットしない。
                // ヒット数が0ならプレイヤーとの間に障害物はないことになる。
                agent.isStopped = false;
                agent.destination = collider.transform.position;
            }
            else
            {
                // 見失ったら停止
                agent.isStopped = true;
            }
            agent.destination = collider.transform.position;
        }
    }
}
