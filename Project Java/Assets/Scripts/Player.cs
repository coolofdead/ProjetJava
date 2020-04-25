using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable
{
    public Vehicle player1;
    public Vehicle player2;

    public static bool victory = true;

    public int maxLife = 100;
    private int life;
    public float Life { get { return life; } }

    public static Player player;
    private int score;
    public int Score { get { return score; } set { score = value; } }

    private float lastHit;
    private float autoRecoveryTime = 6f;

    private void Awake()
    {
        player = this;
        life = maxLife;
        StartCoroutine(RecoveringLife());
    }

    public void TakeDamage(int amount, bool instantKill = false)
    {
        lastHit = Time.time;
        life -= instantKill ? life : amount;

        if (life <= 0)
        {
            life = 0;
            victory = false;
            SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
        }
    }

    IEnumerator RecoveringLife()
    {
        while (true)
        {
            yield return new WaitWhile(() => { return (lastHit + autoRecoveryTime > Time.time); });

            yield return new WaitForSeconds(0.5f);
            if ((lastHit + autoRecoveryTime <= Time.time))
                life = life + 1 > maxLife ? maxLife : life + 1;
        }
    }
}
