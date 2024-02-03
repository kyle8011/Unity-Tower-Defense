using System;
using UnityEngine;
[Serializable]
public class Tower1
{
    public string name;
    public int cost;
    public GameObject prefab;

    public Tower1 (string _name, int _cost, GameObject _prefab) {
        name = _name;
        cost = _cost;
        prefab = _prefab;
    }
}
