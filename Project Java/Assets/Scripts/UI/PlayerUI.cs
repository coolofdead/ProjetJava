using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private Image lifeBar;

    private void Start()
    {
        lifeBar = GetComponent<Image>();
    }

    void Update()
    {
        lifeBar.fillAmount = Player.player.Life / Player.player.maxLife;
    }
}
