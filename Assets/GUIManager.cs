using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public Text KillInfo;
    public Text SpeedInfo;
    public Text DashInfo;
    private int totalKills = 0;
    private EnemyBehaviour enemyBehaviour;
    
    void Awake()
    {
        GameObject enemy = GameObject.FindWithTag("Enemy");
        enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddKill()
    {
        totalKills++;
        KillInfo.text = "Kill Count: " + totalKills;
        Debug.Log("Kill count updated: " + totalKills);
    }
}
