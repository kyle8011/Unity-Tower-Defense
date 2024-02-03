using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;

    [Header("References")]
    //[SerializeField] private GameObject[] towerPrefabs;
    [SerializeField] private Tower1[] towers;

    private int selectedTower = 0;
    private void Awake() {
        main = this;
    }

    public Tower1 GetSelectedTower() {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower) {
        selectedTower = _selectedTower;
    }

}
