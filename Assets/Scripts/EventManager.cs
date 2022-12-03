using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action OnEnemyKilled;
    public static Action GameOver;
    public static Action OnHeroDie;

    public static void SendEnemyKilled()
    {
        if (OnEnemyKilled != null)
        {
            OnEnemyKilled.Invoke();
        }
    }
    public static void SendGameOver()
    {
        if (GameOver != null)
        {
            GameOver.Invoke();
        }
    }

    public static void SendHeroDie()
    {
        if (OnHeroDie != null)
        {
            OnHeroDie.Invoke();
        }
    }
}
