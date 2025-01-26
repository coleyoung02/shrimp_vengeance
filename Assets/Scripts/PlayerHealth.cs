using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("LoseScene");
            }
            for (int i = 0; i < hearts.Count; i++)
            {
                if (i + 1 > currentHealth)
                {
                    hearts[i].SetActive(false);
                }
            }
            if (!(e is BossTarget))
            {
                Destroy(e.gameObject, .25f);
            }
        }
        else if (collision.gameObject.tag.Equals("kill"))
        {
            SceneManager.LoadScene("LoseScene");
        }
        else
        {
            Debug.Log("non event collision " + collision.gameObject.tag);
        }
    }
}
