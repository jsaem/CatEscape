using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum GameState
{
    InGame = 0,
    GameOver = 1
}

public class GameDirector : MonoBehaviour
{
    GameObject hpGage;
    Image hpImg = null;
    public Text goldText;
    public Text resultGoldText;
    public Text hpText;
    int hpInt = 100;
    int goldAmount = 0;
    static public GameState s_State;
    public Button m_resetBtn;
    public GameObject GameOverPanel;
    PrefabsGenerator a_prefabGen;
    PlayerController a_PlayerCtrl;

    // Start is called before the first frame update
    void Start()
    {
        GameObject a_pgObj = GameObject.Find("PrefabsGenerator");
        if (a_pgObj != null)
            a_prefabGen = a_pgObj.GetComponent<PrefabsGenerator>();

        GameObject a_pcObj = GameObject.Find("PlayerController");
        if (a_pcObj != null)
            a_PlayerCtrl = a_pcObj.GetComponent<PlayerController>();

        this.hpGage = GameObject.Find("hpGage");
        if (hpGage != null)
            hpImg = this.hpGage.GetComponent<Image>();

        s_State = GameState.InGame;

        if (m_resetBtn != null)
            m_resetBtn.onClick.AddListener(ResetFunc);
    }

    void Update()
    {
        switch (s_State)
        {
            case GameState.InGame:
                Time.timeScale = 1f;
                GameOverPanel.SetActive(false);
                this.hpGage.SetActive(true);
                break;
            case GameState.GameOver:
                Time.timeScale = 0f;
                if (GameOverPanel != null)
                    GameOverPanel.SetActive(true);
                this.hpGage.SetActive(false);
                if (resultGoldText != null)
                    resultGoldText.text = "Gold : " + goldAmount;
                break;
        }
    }

    public void DecreaseHp()
    {
        if (hpImg == null || hpText == null) // 예외처리
            return;

        hpImg.fillAmount -= 0.1f;
        hpInt -= 10;
        hpText.text = "" + hpInt + "%";

        if (hpImg.fillAmount <= 0f)
        {
            s_State = GameState.GameOver;
        }
    }

    public void addGold()
    {
        if (hpImg == null)
            return;

        if (hpImg.fillAmount <= 0.0f)
        return;

        goldAmount += 10;

        if (goldText != null)
            goldText.text = "Gold : " + goldAmount;
    }

    public void ResetFunc()
    {
        if (a_prefabGen != null)
        {
            a_prefabGen.span = 1.0f;
            a_prefabGen.m_DownSpeedCtrl = -0.1f;
        } 

        if (hpImg != null)
            hpImg.fillAmount = 1.0f;

        if (hpText != null)
            hpInt = 100;
            hpText.text = "" + hpInt + "%";

        goldAmount = 0;

        s_State = GameState.InGame;
    }

    public void addTime()
    {
        if (a_prefabGen != null)
        {
            if (a_prefabGen.span < 1.0f)
                a_prefabGen.span += 1.0f;
            if (a_prefabGen.m_DownSpeedCtrl < -0.1f)
                a_prefabGen.m_DownSpeedCtrl += 0.1f;
        }
    }

    public void addHP()
    {
        if (hpImg == null || hpText == null) // 예외처리
            return;

        if (hpImg.fillAmount >= 1.0f || hpInt > 100) // HP가 100%를 넘어갈때 100%로 정의
        {
            hpImg.fillAmount = 1.0f;
            hpInt = 100;
        }
        else
        {
            hpImg.fillAmount += 0.1f;
            hpInt += 10;
            hpText.text = "" + hpInt + "%";
        }
    }
}
