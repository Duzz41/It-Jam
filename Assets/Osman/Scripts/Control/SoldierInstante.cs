using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoldierInstante : MonoBehaviour
{
    public GameObject soldier;
    public List<GameObject> soldierList = new List<GameObject>();
    public Transform[] spawPos;
    int i;
    private void OnMouseDown()
    {

        // Fare imlecinin konumunu al
        Vector3 mousePosition = Input.mousePosition;

        // Fare imleci dünya koordinatlarına dönüştür
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Raycast işlemi
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            // Fare imlecinin dünya koordinatları ile nesnenin dünya koordinatlarını karşılaştır
            if (hit.collider.gameObject == gameObject)
            {
                if (MoneyManager.instance.money >= 20)
                {
                    if (i < spawPos.Length)
                    {
                        
                        MoneyManager.instance.RemoveMoney(20);
                        GameObject newSoldier = Instantiate(soldier, spawPos[i].position, Quaternion.identity);

                        soldierList.Add(newSoldier);
                        GameManager.instance.currentSoldierCount++;
                        i++;
                        Debug.Log(MoneyManager.instance.money);
                    }
                    else
                        Debug.Log("Yeterli alan yok");
                }
                else
                    Debug.Log("Yeterli paran yok");
                // Nesne ile imlecin konumu çakışıyor, istediğiniz işlemi yapabilirsiniz
            }
        }
    }
}
