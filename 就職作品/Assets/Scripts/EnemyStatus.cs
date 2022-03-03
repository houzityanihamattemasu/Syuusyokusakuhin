using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class EnemyStatus : MobStatus
{
    private NavMeshAgent agent;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("MoveSpeed", agent.velocity.magnitude);
    }
    protected override void OnDie()
    {
        base.OnDie();
        StartCoroutine(DestroyCoroutine());
	}
    private IEnumerator DestroyCoroutine()
    {
		// 3•b‚µ‚Ä‚©‚ç“G‚ªÁ‚¦‚Ä‘JˆÚ‚·‚é
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
		
		
	}
}
