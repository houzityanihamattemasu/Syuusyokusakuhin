using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MobStatus
{
	// Start is called before the first frame update
	void Start()
    {
		base.Start();
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	protected override void OnDie()
	{
		base.OnDie();
		StartCoroutine(GoToGameOverCoroutine());
	}

	private IEnumerator GoToGameOverCoroutine()
	{
		yield return new WaitForSeconds(2); // 2•b‚µ‚Ä‚©‚ç‘JˆÚ
		FadeManager.Instance.LoadScene("GameOver", 2.0f);
	}
}
