using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get;set;}
    public int currentRound = 1;
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
    }

    void Update()
    {
        
    }
}
