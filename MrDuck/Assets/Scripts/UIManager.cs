using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject HelpPanel;
    public void GameStartButtonAction() //게임 시작
    {
        SceneManager.LoadScene("Level_1");
    }

    public void BackToMainMenu()
    {
       
        SceneManager.LoadScene("Level_0"); //되돌아가기
    }

    //도움말
    public void OpenHelpPanel()
    {
        if (HelpPanel != null)
        {
            HelpPanel.SetActive(true);
        }
    }
    //도움말 닫기
    public void CloseHelpPanel()
    {
        if (HelpPanel != null)
        {
            HelpPanel.SetActive(false);
        }
    }

    // 게임 종료
    public void QuitGame()//종료
    {
        Application.Quit();
        Debug.Log("게임이 종료되었습니다."); //얘는 확인용ㅎㅎ
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
