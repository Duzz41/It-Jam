using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    private Camera _camera;
    [SerializeField]
    private Transform _startPos;
    [SerializeField]
    private Transform _target1;
    [SerializeField]
    private Transform _target2;

    void Start()
    {
        _camera = GetComponent<Camera>();
    }
    //Savaş başladığı vakit kameranın hareketini başlatır oyunu başlatacak olan butona bağladım.
    public void CameraMove()
    {
        transform.DOMove(_target1.position, 2f);
        transform.DORotate(_target1.rotation.eulerAngles, 2f).OnComplete(() => MoveSecondLocation());
    }
    void MoveSecondLocation()
    {
        transform.DOMove(_target2.position, 2f);
        transform.DORotate(_target2.rotation.eulerAngles, 2f);
    }
    //Şu anda butona bağlı bunu savaş bittiği vakit olacak olan fonksiyona bağlanacak.
    public void CameraMoveBack()
    {
        transform.DOMove(_target1.position, 2f);
        transform.DORotate(_target1.rotation.eulerAngles, 2f).OnComplete(() => MoveFirstLocation());
    }
    void MoveFirstLocation()
    {
        transform.DOMove(_startPos.position, 2f);
        transform.DORotate(_startPos.rotation.eulerAngles, 2f);
    }
    //Kamera shake her bir askerimiz öldüğünde olur diye düşünüyorum şu anda butona bağlı değişecek.
    public void CameraShake()
    {
        _camera.DOShakePosition(0.5f, 0.5f, 10, 90, false, ShakeRandomnessMode.Full);
    }
}
