using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;

    private SpriteRenderer sprite;
    private float baseSpeed;

    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
        target = LevelManager.main.path[0];
        baseSpeed = moveSpeed;
    }
    private void Update() {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f) {
            pathIndex++;
            // If it hits the last waypoint destroy the enemy
            if (pathIndex >= LevelManager.main.path.Length) {
                EnemySpawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                return;
            }
            // Otherwise just move to the next waypoint as a target
            else {
                target = LevelManager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate() {
        // Change the direction of the enemy
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
        if (direction.x > 0) {
            sprite.flipX = true;
        }
        else {
            sprite.flipX = false;
        }
    }

    public void UpdateSpeed(float newSpeed) {

    }
}
