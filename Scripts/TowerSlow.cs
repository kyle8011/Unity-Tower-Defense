using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSlow : MonoBehaviour
{

    [Header("Referneces")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private LayerMask enemyMask;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 3f;
    [SerializeField] private float aps = 2f; // Attacks per second

    private float timeUntilFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (target == null) {
        //     FindTarget();
        //     return;
        // }

        // RotateTowardsTarget();

        // // If the target is no longer in range
        // if (!CheckTargetIsInRange()) {
        //     target = null;
        // }
        // // If the target is still in range
        // else {
        //     timeUntilFire += Time.deltaTime;
        //     if (timeUntilFire >= 1f / aps) {
        //         FreezeEnemies();
        //         timeUntilFire = 0f;
        //     }
        // }
    }

    private void FreezeEnemies() {

    }
}
