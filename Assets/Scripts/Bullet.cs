using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5;
    public int bulletDamage = 10;
    public int points = 0;
    public Text pointsText; 

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().DoDamage(bulletDamage);
            Destroy(gameObject);

            if (collision.gameObject == null)
            {
                points += 10;
                pointsText.text = "Points: " + points.ToString();
            }
        }
    }
}
