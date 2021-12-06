using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShop : MonoBehaviour
{
    public GameObject towerPrefab;
    public int towerCost = 50;

    public void BuyTowerButtonClick()
    {
        if (Globals.selectedTowerBase == null)
        {
            Debug.Log("Nothing Selected.");
            return;
        }

        //Remove the old tower if there is one.
        if(Globals.selectedTowerBase.transform.childCount > 0)
            Destroy(Globals.selectedTowerBase.transform.GetChild(0).gameObject);

        //Here you would check if the player can afford towerCost and if so, subtract it from their 'money'
        if (PointsManager.pointValue >= towerCost)
        {
            Debug.Log("You have enough points");

            //Create newly purchased tower and make it a child of the 'tower base'
            GameObject newTower = Instantiate(towerPrefab, Globals.selectedTowerBase.transform.position, Quaternion.identity);
            newTower.transform.parent = Globals.selectedTowerBase.transform;

            PointsManager.decreasePoints(towerCost); 
        }
        else
        {
            Debug.Log("Not enough points");
        }


        //Create newly purchased tower and make it a child of the 'tower base'
        //GameObject newTower = Instantiate(towerPrefab, Globals.selectedTowerBase.transform.position, Quaternion.identity);
        //newTower.transform.parent = Globals.selectedTowerBase.transform;
    }
}
