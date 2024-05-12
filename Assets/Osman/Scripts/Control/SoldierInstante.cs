using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
public class SoldierInstante : MonoBehaviour
{
    public GameObject soldier;
    public TextMeshProUGUI _text;
    public List<GameObject> soldierList = new List<GameObject>();
    public Transform[] spawPos;
    public int i;
    void Start()
    {
        i = 0;
        _text.text = GameManager.instance.currentSoldierCount.ToString();
        GameObject newSoldier = Instantiate(soldier, spawPos[i].position, Quaternion.identity);
        soldierList.Add(newSoldier);
        GameManager.instance.currentSoldierCount++;
        i++;
    }
    void Update()
    {
        _text.text = GameManager.instance.currentSoldierCount.ToString();
    }
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
                    if (i < 10)
                    {

                        MoneyManager.instance.RemoveMoney(20);
                        GameObject newSoldier = Instantiate(soldier, spawPos[i].position, spawPos[i].rotation);

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
