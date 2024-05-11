using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _target1;
    [SerializeField]
    private Transform _target2;
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
}
