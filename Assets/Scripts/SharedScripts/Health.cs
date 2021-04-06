using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private const string GAME_OVER = "GameOver";

    public int health;
    public HealthBar healthBar;

    private SceneChange sceneChange;

    // Start is called before the first frame update
    void Start()
    {
        sceneChange = new SceneChange();
        healthBar.setMaxHealth(health);
    }

    //When an enemy touchs an object remove heath
    void OnTriggerEnter2D(Collider2D other)
    {
        // TODO: Make the damage be based on the attack stat of the enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            health -= 1;
            healthBar.setHealth(health);
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
