using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerUI : MonoBehaviour
{
    private Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int score = (int)Time.time * 10;
        timerText.text = score.ToString();
    }
}
