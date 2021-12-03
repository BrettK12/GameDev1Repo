using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    //Ways of getting another script/object's data, Method 1
    //Efficient, but has to be done in the editor manually
    //public WaypointManager waypointManager;
    
    public float speed = 5;
    public float distanceThreshold = .75f;
    public int maxHealth = 10;
    public int points = 0;
    public int totalNumberOfEnemies = 3;
    public Slider healthBar;
    public Text scoreText;

    private Vector2 targetWaypoint;
    private SpriteRenderer sr;
    private int currentHealth;
    private int targetWaypointIndex;
    //private int numOfEnemiesDestroyed = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Ways of getting another script/object's data, Method 2
        //Slowest, but works for objects that didn't exist on game start
        //waypointManager = FindObjectOfType<WaypointManager>();

        //Dynamically adding components:
        //gameObject.AddComponent(typeof(Tower));

        //Ways of getting another script/object's data, Method 3
        targetWaypoint = WaypointManager.staticWaypoints[0];
        targetWaypointIndex = 0;

        sr = GetComponent<SpriteRenderer>();

        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<Slider>();

        
    }
    public void DoDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
           
            points += 10;
            Debug.Log("10 points were added");
            scoreText.text = "Points: " + points.ToString();
        }
        healthBar.value = (float)currentHealth / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionToMove = targetWaypoint - (Vector2)transform.position;
        float distance = directionToMove.magnitude;
        if (distance < distanceThreshold)
        {
            if (targetWaypointIndex == WaypointManager.staticWaypoints.Count - 1)
                return;
            targetWaypoint = WaypointManager.staticWaypoints[++targetWaypointIndex];
            directionToMove = targetWaypoint - (Vector2)transform.position;
        }

        directionToMove.Normalize();
        transform.Translate(directionToMove * speed * Time.deltaTime);
        if (directionToMove.x > .01)
            sr.flipX = true;
        else
            sr.flipX = false;

        
    }

    void StartNextLevel()
    {
        SceneManager.LoadScene("Level2");
    }

    void FixedUpdate()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }
}
