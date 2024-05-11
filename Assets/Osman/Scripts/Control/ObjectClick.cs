using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick : MonoBehaviour
{
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
                if (GameManager.instance.currentSoldierCount != 0)
                {
                    GameManager.instance.SpawnAllEnemies();
                    EvntManager.TriggerEvent("Atack");
                    EvntManager.TriggerEvent("CameraMove");
                }
                // Nesne ile imlecin konumu çakışıyor, istediğiniz işlemi yapabilirsiniz
            }
        }
    }
}
