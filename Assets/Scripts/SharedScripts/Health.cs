using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const string GAME_OVER = "GameOver";

    public int health;
    public HealthUI heartContainers;

    private SceneChange sceneChange;

    // Start is called before the first frame update
    void Start()
    {
        sceneChange = new SceneChange();
    }

    //When an enemy touchs an object remove heath
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health -= 1;
            heartContainers.reduceHeartContainers();
        }
    }

    void LateUpdate()
    {
        if (health == 0)
        {
            sceneChange.changeScene(GAME_OVER);
        }
    }
}
