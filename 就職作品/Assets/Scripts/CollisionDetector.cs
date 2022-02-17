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
    // TriggerがOnで他のColliderと重なっているときは常に呼ばれる
    private void OnTriggerStay(Collider other)
    {
        // InspectorタブのonTriggerStayで指定された処理を実行する
        onTriggerStay.Invoke(other);
    }

    [Serializable]
    // UnityEventを継承したクラスに[Serializable]を与することで
    // インスペクター上に表示できるように
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
