using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get;set;}
    public int CurrentRound {get;set;}
    public bool LockCamera {get;set;}
    public bool GameOver {get;set;}
    public int EnemyCount {get;set;}

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance        = this;
        CurrentRound    = 0;
        LockCamera      = false;
        GameOver        = false;
        EnemyCount      = 0;

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LockCamera = !LockCamera;
        }

        if(EnemyCount == 0)
        {
            CurrentRound++;
        }
    }
}
