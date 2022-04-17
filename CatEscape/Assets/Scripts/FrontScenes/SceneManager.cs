using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public Button m_explain_Btn;
    public Button m_start_Btn;
    public Button m_quit_Btn;

    // Start is called before the first frame update
    void Start()
    {
        if (m_explain_Btn != null)
            m_explain_Btn.onClick.AddListener(explanationFunc);
        if (m_start_Btn != null)
            m_start_Btn.onClick.AddListener(startFunc);
        if (m_quit_Btn != null)
            m_quit_Btn.onClick.AddListener(quitFunc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void explanationFunc()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ExplanationScene");
    }


    void startFunc()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }

    void quitFunc()
    {
        Application.Quit();
    }
}
