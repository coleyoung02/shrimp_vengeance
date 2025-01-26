using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject bubble;
    public void StartGame()
    {
        StartCoroutine(Game());
    }

    public void Quit()
    {
        Application.Quit();
    }

    private IEnumerator Game()
    {
        for (int i = 0; i < 150; ++i)
        {
            Instantiate(bubble, transform.position + Vector3.right *
                UnityEngine.Random.Range(((RectTransform)transform).rect.width / -2f, ((RectTransform)transform).rect.width / 2f),
                Quaternion.identity, transform);
            yield return new WaitForSeconds(1f / 120);
        }
        SceneManager.LoadSceneAsync(1); 
        for (int i = 0; i < 500; ++i)
        {
            Instantiate(bubble, transform.position + Vector3.right * 
                UnityEngine.Random.Range(((RectTransform)transform).rect.width / -2f, ((RectTransform)transform).rect.width / 2f), 
                Quaternion.identity, transform);
            yield return new WaitForSeconds(1f / 120);
        }

    }
}
