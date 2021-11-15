using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    public Slider healthBar;
    public int maxHealth = 100;
    public GameObject gameOverPanel;

    int health;

    private void Start()
    {
        health = maxHealth;
    }

    public void DoDamage(int amount)
    {
        health -= amount;

        //Restart if base died.
        if (health <= 0)
        {
            //UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            gameOverPanel.SetActive(true);
        }
            

        //otherwise update healthbar.
        healthBar.value = (float)health / maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            DoDamage(5);//Should add and get this value from the enemy component on the enemy instead.
            Destroy(collision.gameObject);
        }
    }
}
