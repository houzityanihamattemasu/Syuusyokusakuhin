using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyStatus : MobStatus
{
    private NavMeshAgent agent;
    //private bool bflg;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        //bflg = false;
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
        //if(bflg)
        //{
        //    FadeManager.Instance.LoadScene("Clear", 2.0f);
        //}
        FadeManager.Instance.LoadScene("Clear", 2.0f);

    }
    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        //bflg = true;
    }
}
