using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    private bool flg;

    public void ButtonExit()
    {
        //UnityEditor.EditorApplication.isPlaying = false; // Editor���Debug�I��邽�߂ɏ����܂����B
        Application.Quit(); // Unity�̃Q�[���I���B
    }

    // Start is called before the first frame update
    void Start()
    {
        flg = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick(string select)
    {
        if(flg)
        {
            FadeManager.Instance.LoadScene(select, 2.0f);
            flg = false;
        }
        
    }
}
