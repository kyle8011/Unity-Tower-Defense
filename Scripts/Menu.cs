using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{

    [Header("References")]
    [SerializeField] TextMeshProUGUI moneyUI;
    [SerializeField] Animator anim;

    private bool isMenuOpen = true;

    private void OnGUI() {
        moneyUI.text = LevelManager.main.money.ToString();
    }

    public void SetSelected() {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("MenuOpen", isMenuOpen);
    }
}
