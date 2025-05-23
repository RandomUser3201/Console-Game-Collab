using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;


    // Enemy Health Manager
    public float health = 100f;
    public float maxHealth = 100f;
    private Text healthText;
    public GameObject healthDisplayPrefab;
    private GameObject healthDisplay;
    private GUIManager gui;
    public int killCount;
    private SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        gui = FindObjectOfType<GUIManager>();
        agent = GetComponent<NavMeshAgent>();
        soundManager = FindObjectOfType<SoundManager>();

        healthDisplay = Instantiate(healthDisplayPrefab, transform);
        healthDisplay.transform.localPosition = new Vector3(0, 2, 0);

        healthText = healthDisplay.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);

        healthText.text = Mathf.RoundToInt(health).ToString();
        transform.LookAt(Camera.main.transform);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(25f);
            Debug.LogWarning("Enemy Q Damage");
        }
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Enemy took damage: " + damage + " Current Health: " + health);

        if (health <= 0)
        {
            health = 0;
            healthText.text = "0";
            Debug.LogWarning("Health is now 0: " + health);

            gui.AddKill();
            Destroy(gameObject);
            soundManager.PlayDeathSFX();
        }
    }

    // public float HealthPercentage()
    // {
    //     return health / maxHealth;
    // }
}