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
    private bool _isFighting = false;

    void Start()
    {
        _camera = GetComponent<Camera>();
        EvntManager.StartListening("CameraMove", CameraMove);
        EvntManager.StartListening("CameraMoveBack", CameraMoveBack);
        EvntManager.StartListening("CameraShake", CameraShake);
    }
    //Savaş başladığı vakit kameranın hareketini başlatır oyunu başlatacak olan butona bağladım.
    public void CameraMove()
    {
        if (_isFighting == false)
        {
            _isFighting = true;
            transform.DOMove(_target1.position, 5f);
            transform.DORotate(_target1.rotation.eulerAngles, 5f).OnComplete(() => MoveSecondLocation());
        }
    }
    void MoveSecondLocation()
    {
        transform.DOMove(_target2.position, 4f);
        transform.DORotate(_target2.rotation.eulerAngles, 4f).OnComplete(() => _isFighting = false);
    }
    //Şu anda butona bağlı bunu savaş bittiği vakit olacak olan fonksiyona bağlanacak.
    public void CameraMoveBack()
    {
        transform.DOMove(_target1.position, 4f);
        transform.DORotate(_target1.rotation.eulerAngles, 4f).OnComplete(() => MoveFirstLocation());
    }
    void MoveFirstLocation()
    {
        transform.DOMove(_startPos.position, 5f);
        transform.DORotate(_startPos.rotation.eulerAngles, 5f);
    }
    //Kamera shake her bir askerimiz öldüğünde olur diye düşünüyorum şu anda butona bağlı değişecek.
    public void CameraShake()
    {
        _camera.DOShakePosition(0.5f, 0.25f, 10, 90, false, ShakeRandomnessMode.Full);
    }
}
