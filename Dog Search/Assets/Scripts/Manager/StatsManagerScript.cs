using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManagerScript : MonoBehaviour
{
    private static StatsManagerScript _instance;

    public static StatsManagerScript Instance { get { return _instance; } }


    bool TenisBallPowerUp = false;

    float TenisBalls;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public bool GetTenisBallPowerUp()
    {
        return TenisBallPowerUp;
    }

    public float GetTenisBalls()
    {
        return TenisBalls;
    }
}
