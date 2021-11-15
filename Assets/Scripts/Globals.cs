using UnityEngine;

public class Globals : MonoBehaviour
{
    public static GameObject selectedTowerBase;

    public static void ChangeSelectedTower(GameObject tower)
    {
        if (selectedTowerBase == tower)//Trying to select the tower that is already selected.
            return;

        //Deselect previous tower, if there is one
        if (selectedTowerBase != null)
        {
            selectedTowerBase.GetComponent<SpriteRenderer>().color = Color.white;
            selectedTowerBase = null;
        }

        //Select new tower, if there is one
        if (tower != null)
        {
            selectedTowerBase = tower;
            selectedTowerBase.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }
}
