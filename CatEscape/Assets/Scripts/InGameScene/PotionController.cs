using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
    GameObject player;
    [HideInInspector] public float m_DownSpeed = -0.1f; // 애플 하나의 낙하 속도
    GameDirector m_gameDir;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player"); // 플레이어 저장

        GameObject a_gdObj = GameObject.Find("GameDirector");
        if (a_gdObj != null)
            m_gameDir = a_gdObj.GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        // 프레임마다 등속으로 낙하시킨다
        transform.Translate(0, m_DownSpeed, 0);

        // 화면 밖으로 나오면 오브젝트를 소멸시킨다
        if (transform.position.y < -5.0f)
            Destroy(gameObject);

        // ---- 충돌 판정
        Vector2 p1 = transform.position; // 화살의 중심 좌표
        Vector2 p2 = this.player.transform.position; // 플레이어의 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f; // 화살 반경
        float r2 = 1.0f; // 플레이어 반경

        if (d < r1 + r2) // 충돌하면...
        {
            // 화살을 소멸시킨다
            Destroy(gameObject);
            // ---- 충돌 판정

            m_gameDir.addHP();
        }
    }
}
