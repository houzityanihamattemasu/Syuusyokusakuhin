using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private TriggerEvent onTriggerEnter = new TriggerEvent();
    [SerializeField] private TriggerEvent onTriggerStay = new TriggerEvent();

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other);
    }
    // Trigger��On�ő���Collider�Əd�Ȃ��Ă���Ƃ��͏�ɌĂ΂��
    private void OnTriggerStay(Collider other)
    {
        // Inspector�^�u��onTriggerStay�Ŏw�肳�ꂽ���������s����
        onTriggerStay.Invoke(other);
    }

    [Serializable]
    // UnityEvent���p�������N���X��[Serializable]��^���邱�Ƃ�
    // �C���X�y�N�^�[��ɕ\���ł���悤��
    public class TriggerEvent : UnityEvent<Collider>
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
