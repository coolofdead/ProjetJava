using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YwingShield : MonoBehaviour
{
    public Shield yWingShield;
    public Image shieldBar;

    public Color warningColor;
    public Color regeneratingShieldColor;
    private Color defaultColor;

    public GameObject warning;

    private void Start()
    {
        defaultColor = shieldBar.color;
    }

    void Update()
    {
        float amount = yWingShield.ActifTimeLeft / yWingShield.recoveryTime;
        shieldBar.fillAmount = amount;

        shieldBar.color = amount < 0.3f ? warningColor : defaultColor;
        if (yWingShield.IsRecovering)
            shieldBar.color = regeneratingShieldColor;

        warning.SetActive(amount < 0.2f);
    }
}
