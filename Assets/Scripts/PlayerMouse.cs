using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouse : MonoBehaviour
{
    Vector3 mouseWorldPosition;
    public GameObject pausePanel;
    bool clickReleased = true;
    bool mouseOverUI = false;

    // Update is called once per frame
    void Update()
    {
        //Pause Menu
        if (Input.GetAxis("Pause") == 1)
        {
            pausePanel.SetActive(true);
            //Time.timeScale = 0;
        }
            

        //make player mouse collider follow the cursor
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        transform.position = mouseWorldPosition;

        //Interact with non-UI game objects.
        bool mouseClicked = Input.GetAxis("Fire1") == 1;
        if (mouseClicked && clickReleased && !mouseOverUI)//Just clicked the mouse the first time since releasing it, in a valid location (i.e. not on a UI element like the shop panel)
            Globals.ChangeSelectedTower(null);
        else if (!mouseClicked && !clickReleased)//Just let go of the mouse
            clickReleased = true;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ShopPanel")
            mouseOverUI = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ShopPanel")
            mouseOverUI = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!clickReleased || mouseOverUI)
            return;

        if (Input.GetAxis("Fire1") == 1)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                clickReleased = false;
                collision.gameObject.GetComponent<Enemy>().DoDamage(5);
            }
            else if(collision.gameObject.tag == "TowerBase")
            {
                clickReleased = false;
                Globals.ChangeSelectedTower(collision.gameObject);
            }
        }
    }
}
