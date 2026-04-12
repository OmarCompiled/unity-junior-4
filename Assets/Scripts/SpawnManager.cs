using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private Transform enemyPrefab; // defies clean naming conventions but whatever :/

    private Transform player;
    private int currentRound = 0;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    } 

    void Update()
    {
        if(currentRound != GameManager.Instance.currentRound)
        {
            currentRound++;
            SpawnEnemies(currentRound);
        }
    }

    Vector3 RandomPosition()
    {
        float xOffset = Random.Range(1.0f, 5.0f);
        float yOffset = 2.0f;
        float zOffset = Random.Range(1.0f, 5.0f);
        Vector3 offset = new Vector3(xOffset, yOffset, zOffset);
        return player.position + offset;
    }

    void SpawnEnemies(int round)
    {
        
    }
}