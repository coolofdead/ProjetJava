using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalIndicator : MonoBehaviour
{
    [HideInInspector]
    public Enemy reference;
    private Transform besideTo;

    public GameObject enemyLife;
    public Image enemyLifeBar;
    public Image image;

    [SerializeField]
    private float radius;

    private void Start()
    {
        besideTo = Player.player.transform;
    }

    void Update()
    {
        if (SpaceshipManager.enemyTargetingPlayer == null)
        {
            return;
        }
        else
        {
            reference = (Enemy)SpaceshipManager.enemyTargetingPlayer;
        }

        image.enabled = reference != null;
        enemyLife.SetActive(reference != null);

        if (reference == null)
            return;

        enemyLifeBar.fillAmount = (float)reference.Life / (float)reference.maxLife;

        var dir = (reference.transform.position - besideTo.position).normalized;
        var pos = new Vector3(dir.x, dir.z, 0) * radius;
        image.transform.localPosition = pos;
    }
}
