using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    
    [Header("Attributes")]
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    public void SetTarget(Transform _target) {
        target = _target;
    }
    private Transform target;
    private void FixedUpdate() {
        // If there is no target do nothing
        if (!target) return;
        // Otherwise set the projectile direction
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * projectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Destroy(gameObject);
    }
}
