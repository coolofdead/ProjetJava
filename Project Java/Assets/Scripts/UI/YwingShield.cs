using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YwingShield : MonoBehaviour
{
    public Shield shield;
    public Image shieldDisabled;
    public Image shieldOverHeating;
    public Text countdown;

    void Update()
    {
        shieldDisabled.gameObject.SetActive(shield.IsRecovering);
        countdown.gameObject.SetActive(shield.IsRecovering);

        shieldOverHeating.fillAmount = 1 - shield.ActifTimeLeft / shield.recoveryTime;

        if (!shield.IsRecovering)
            return;

        float amount =  1 - shield.ActifTimeLeft / shield.recoveryTime;
        shieldDisabled.fillAmount = amount;

        countdown.text = (shield.recoveryTime - shield.ActifTimeLeft).ToString("0");
    }
}
