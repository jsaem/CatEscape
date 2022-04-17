using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyDirector : MonoBehaviour
{
    public Button m_Lobby_Btn;

    // Start is called before the first frame update
    void Start()
    {
        if (m_Lobby_Btn != null)
            m_Lobby_Btn.onClick.AddListener(lobbyFunc);
    }

    void lobbyFunc()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
