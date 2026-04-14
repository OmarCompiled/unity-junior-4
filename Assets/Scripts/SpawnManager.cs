using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private Transform enemyPrefab; // defies clean naming conventions but whatever :/

    [SerializeField]
    private Transform powerupPrefab;

    private Transform player;
    private int currentRound = 0;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    } 

    void Update()
    {
        if(currentRound != GameManager.Instance.CurrentRound)
        {
            currentRound++;
            SpawnEnemies(currentRound);
            SpawnPowerups();
        }
    }

    Vector3 RandomPosition(float maxOffset)
    {
        float xOffset = Random.Range(1.0f, maxOffset);
        float yOffset = 2.0f;
        float zOffset = Random.Range(1.0f, maxOffset);
        Vector3 offset = new Vector3(xOffset, yOffset, zOffset);
        return offset;
    }

    void SpawnEnemies(int round)
    {
        for(int i = 0; i < round; i++)
        {
            enemyPrefab.position = player.position + RandomPosition(5.0f);
            Instantiate(enemyPrefab);
            GameManager.Instance.EnemyCount++;
        }
    }

    void SpawnPowerups()
    {
        int count = Random.Range(1, 3);
        for(int i = 0; i < count; i++)
        {
            powerupPrefab.position = RandomPosition(7.5f);
            Instantiate(powerupPrefab);
        }
    }
}