using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tower : MonoBehaviour
{
    [Header("Referneces")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private LayerMask enemyMask;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 3f;
    [SerializeField] private float bps = 1f; // Bullets per second
    // Use this if you don't want the tower to change directions immediately
    //[SerializeField] private float rotationSpeed = 200f;

    private Transform target;
    private float timeUntilFire;

    private SpriteRenderer sprite;

    private void OnDrawGizmosSelected() {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

        // If the target is no longer in range
        if (!CheckTargetIsInRange()) {
            target = null;
        }
        // If the target is still in range
        else {
            timeUntilFire += Time.deltaTime;
            if (timeUntilFire >= 1f / bps) {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }

    private void Shoot() {
        GameObject projectileObj = Instantiate(projectilePrefab, firingPoint.position, Quaternion.identity);
        Projectile projectileScript = projectileObj.GetComponent<Projectile>();
        projectileScript.SetTarget(target);
    }

    private void RotateTowardsTarget() {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        if (angle > 90 || angle < -90) {
            sprite.flipY = true;
        }
        else {
            sprite.flipY = false;
        }

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        transform.rotation = targetRotation;
        // Use this in conjunction with rotationSpeed for not snapping immediately when a new target is located
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void FindTarget() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2) transform.position, 0f, enemyMask);
        
        if (hits.Length > 0) {
            target = hits[0].transform;
        }
                                                
    }

    private bool CheckTargetIsInRange() {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }
}
