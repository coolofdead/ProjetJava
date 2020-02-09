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
        image.enabled = reference != null;
        enemyLife.SetActive(reference != null);

        if (reference == null)
            return;

        enemyLifeBar.fillAmount = (float)reference.Life / (float)reference.maxLife;

        var dir = reference.transform.position - besideTo.position;
        image.transform.localPosition = new Vector3(dir.normalized.x, dir.normalized.z, 0) * radius;
    }
}
