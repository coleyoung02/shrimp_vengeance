using UnityEngine;

public class MenuBubble : MonoBehaviour
{
    private float upSpeed;
    private float sideSpeed;
    private float sideMult;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upSpeed = UnityEngine.Random.Range(1f, 1.1f);
        sideSpeed = UnityEngine.Random.Range(.1f, .125f);
        sideMult = UnityEngine.Random.Range(.8f, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(Vector2.up * upSpeed + Vector2.right * sideSpeed * Mathf.Sin(Time.time * sideMult)) * Time.deltaTime * 1000;
    }
}
