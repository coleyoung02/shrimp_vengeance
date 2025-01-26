using UnityEngine;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private List<GameObject> hearts;
    [SerializeField] private int maxHealth;

    private int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy e = collision.gameObject.GetComponent<Enemy>();
        if (e != null)
        {
            currentHealth--;
            for (int i = 0; i < hearts.Count; i++)
            {
                if (i + 1 > currentHealth)
                {
                    hearts[i].SetActive(false);
                }
            }
            Destroy(e.gameObject, .25f);
        }
    }
}
