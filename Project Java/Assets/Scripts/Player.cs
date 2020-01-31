using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public Vehicle player1;
    public Vehicle player2;

    [SerializeField]
    private int life = 3;
    public GameObject[] fireImpacts;

    public static Player player;
    private int score;
    public int Score { get { return score; } set { score = value; } }

    private void Awake()
    {
        player = this;
    }

    public void TakeDamage(int amount, bool instantKill = false)
    {
        life -= instantKill ? life : amount;

        if (life <= 0)
        {
            life = 0;
            Debug.Log("Player die");
        }

        for (int i = 0; i < 3 - life; i++)
            fireImpacts[i].SetActive(true);
    }
}
