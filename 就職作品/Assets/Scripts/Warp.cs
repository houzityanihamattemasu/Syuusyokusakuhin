using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    public GameObject[] PlayerLife;
    public int WarpCnt = 0;　// プレイヤーがワープした回数

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = new Vector3(0.5f, 1.0f, -8.0f);
        WarpCnt += 1;
        UpdatePlayerLife();
        if(WarpCnt == 3)
        {
            FadeManager.Instance.LoadScene("GameOver", 0.5f);
        }
    }

    // プレイヤーの残機を表示する
    void UpdatePlayerLife()
    {
        for(int i = 0; i < PlayerLife.Length; i++)
        {
            if(WarpCnt <= i)
            {
                PlayerLife[i].SetActive(true);
            }
            else
            {
                PlayerLife[i].SetActive(false); // 非表示にする
            }
        }
    }
    
}
