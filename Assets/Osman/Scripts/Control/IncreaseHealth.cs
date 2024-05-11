using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealth : MonoBehaviour
{
    private int upgradeCost = 20;
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
                if (MoneyManager.instance.money >= upgradeCost)
                {

                    MoneyManager.instance.RemoveMoney(upgradeCost);
                    EvntManager.TriggerEvent("IncrHealth", 10);
                    upgradeCost += upgradeCost;
                    Debug.Log(MoneyManager.instance.money);
                }
                else
                    Debug.Log("Yeterli paran yok");
                // Nesne ile imlecin konumu çakışıyor, istediğiniz işlemi yapabilirsiniz
            }
        }
    }
}
