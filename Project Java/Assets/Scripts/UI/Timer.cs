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
        text.text = Time.time.ToString("0.00").Replace(',', ':');
    }
}
