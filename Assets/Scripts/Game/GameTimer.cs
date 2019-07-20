using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float gameDuration = 60;
    private float timePassed;

    public float TimePassed
    {
        get => timePassed;
        set
        {
            if (value != timePassed)
            {
                timePassed = value;
                OnTimeChanged?.Invoke();
            }
        }
    }
    public float TimeRemain
    {
        get => gameDuration - timePassed;
    }

    public event System.Action OnTimeChanged;
    public event System.Action OnTimeOver;
    private void Update()
    {
        TimePassed += Time.deltaTime;
        if (TimePassed >= gameDuration)
        {
            OnTimeOver?.Invoke();
            enabled = false;
        }
    }
}
