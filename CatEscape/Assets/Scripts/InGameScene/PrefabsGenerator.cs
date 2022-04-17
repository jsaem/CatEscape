using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject applePrefab;
    public GameObject clockPrefab;
    public GameObject potionPrefab;

    [HideInInspector] public float span = 1.0f;
    float delta = 0f;

    [HideInInspector] public float m_DownSpeedCtrl = -0.1f; //전체를 제어하는 낙하속도

    // Update is called once per frame
    void Update()
    {
        m_DownSpeedCtrl -= (Time.deltaTime * 0.01f);
        if (m_DownSpeedCtrl < -0.3f)
            m_DownSpeedCtrl = -0.3f;

        this.span -= (Time.deltaTime * 0.03f); //Difficulty Time
        if (1.0f < this.span) // 0.2f 딜레이
            this.span = 1.0f;
        if (this.span < 0.1f)
            this.span = 0.1f;

        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = null;
            int prefabChance = Random.Range(1, 16); // 1-15까지의 숫자

            switch (prefabChance)
            {
                case 1: // appx. 6% for clock
                    go = Instantiate(clockPrefab) as GameObject;
                    go.GetComponent<ClockController>().m_DownSpeed = m_DownSpeedCtrl;
                    break;
                case 2: // appx. 6% for potion
                    go = Instantiate(potionPrefab) as GameObject;
                    go.GetComponent<PotionController>().m_DownSpeed = m_DownSpeedCtrl;
                    break;
                case 3:
                case 4:
                case 5: // appx. 18% for apple
                    go = Instantiate(applePrefab) as GameObject;
                    go.GetComponent<AppleController>().m_DownSpeed = m_DownSpeedCtrl;
                    break;
                default: // appx. 70% for arrow
                    go = Instantiate(arrowPrefab) as GameObject;
                    go.GetComponent<ArrowController>().m_DownSpeed = m_DownSpeedCtrl;
                    break;
            }

            int px = Random.Range(-8, 9);
            go.transform.position = new Vector3(px, 9, 0);
        }
    }
}