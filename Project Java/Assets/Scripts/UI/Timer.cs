using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        int min = (int)(Time.time / 60);
        text.text = min.ToString("0") + ":" + (Time.time - min * 60).ToString("0.00").Replace(',', ':');
    }
}
