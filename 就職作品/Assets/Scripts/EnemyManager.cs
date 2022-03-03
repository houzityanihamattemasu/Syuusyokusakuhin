using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
	private GameObject[] enemies;
	private bool flg;
    // Start is called before the first frame update
    void Start()
    {
		flg = true;
	}

    // Update is called once per frame
    void Update()
    {
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		if (enemies.Length == 0 && flg)
		{
			FadeManager.Instance.LoadScene("Clear", 2.0f);
			flg = false;
		}
	}
	
}
