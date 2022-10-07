using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
    
{
    private Menu menu;
    private void Start()
    {
     menu = GameObject.FindWithTag("Menu").GetComponent<Menu>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        GameObject whois = other.gameObject;
        if (whois.tag == "Enemy")
        {
            Debug.Log("Zadel Enemy");
            Destroy(gameObject);
            menu.GameOver();
            // Destroy(whois);
        }
        if (whois.tag == "Coin")
        {
            Debug.Log("Zadel Coin");
            menu.score += 1;
            Destroy(whois);
            if (menu.score >= menu.numberOfcoint)
            {
                menu.Victory();
            }

            // Destroy(whois);
        }

    }
}
