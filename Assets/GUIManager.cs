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
    private Movement movement;
    
    void Awake()
    {
    //     GameObject enemy = GameObject.FindWithTag("Enemy");
    //     enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();

        GameObject player = GameObject.FindWithTag("Player");
        movement = player.GetComponent<Movement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PowerupTracker();
    }

    public void AddKill()
    {
        totalKills++;
        KillInfo.text = "Kill Count: " + totalKills;
        Debug.Log("Kill count updated: " + totalKills);
    }

    public void PowerupTracker()
    {
        DashInfo.text = "Dash Point: " + movement.dashPoint + "/3"; 
    }
}
