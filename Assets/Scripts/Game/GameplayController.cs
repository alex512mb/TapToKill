using UnityEngine;

public class GameplayController : MonoBehaviour
{

    [Range(0, 100)]
    public float chanceMakeNegativeTarget = 50;
    public SpawnerInArea spawnerPlayerTargets;

    private int playerScores;
    public int PlayerScores
    {
        get => playerScores;
        set
        {
            int clampedValue = Mathf.Clamp(value, 0, int.MaxValue);
            if (playerScores != clampedValue)
            {
                OnScoresChanges?.Invoke(clampedValue);
                playerScores = clampedValue;
            }
        }
    }

    public event System.Action<int> OnScoresChanges;


    private void Awake()
    {
        spawnerPlayerTargets.OnObjectSpawned += OnPlayerTargetSpawned;
    }


    private void OnPlayerTargetSpawned(GameObject obj)
    {
        Target target = obj.GetComponent<Target>();
        if (target != null)
        {
            //try make negative target
            int randomInt = Random.Range(0, 100);
            if (chanceMakeNegativeTarget > randomInt)
            {
                target.negative = true;
            }
            target.OnTargetDestroyed += AddScores;
        }
    }

    private void AddScores(int scores)
    {
        PlayerScores += scores;
    }


    public void GameOver()
    {
        spawnerPlayerTargets.enabled = false;
    }

}
