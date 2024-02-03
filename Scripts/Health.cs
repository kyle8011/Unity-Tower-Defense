using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

     [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int moneyWorth = 50;
    

    private bool isDestroyed = false;
    [SerializeField] private Rigidbody2D rb;
    public void TakeDamage(int dmg) {
        hitPoints -= dmg;

        if (hitPoints <= 0 && !isDestroyed) {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseMoney(moneyWorth);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }

}
