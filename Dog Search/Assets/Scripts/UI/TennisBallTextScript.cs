using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TennisBallTextScript : MonoBehaviour
{
    Text UIText;
    StatsManagerScript stats;

    // Start is called before the first frame update
    void Start()
    {
        UIText = GetComponent<Text>();
        stats = StatsManagerScript.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        UIText.text = "X " + stats;
    }
}
