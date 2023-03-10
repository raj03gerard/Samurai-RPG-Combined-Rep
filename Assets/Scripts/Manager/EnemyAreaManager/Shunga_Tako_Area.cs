using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shunga_Tako_Area : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.enemy_engaged_with = GameManager.EnemyNames.Shunga_Tako;
            gameManager.PlayBossCinematic(GameManager.EnemyNames.Shunga_Tako);
            Debug.Log("Player Entered Shunga Tako territory");
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.enemy_engaged_with = GameManager.EnemyNames.Default;
            gameManager.isFightingBoss = false;
        }
    }
}
