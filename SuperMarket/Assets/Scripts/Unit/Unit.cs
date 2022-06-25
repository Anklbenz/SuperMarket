using Enums;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Unit : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform carryTransform;
    [SerializeField] private GameObject maxLabel;
    [SerializeField] private int storeSize;
    [SerializeField] private Vector3 offsetVector;

    private bool CanPut => _store.HasFreeSpace;
    private bool CanGet => _store.Items.Count > 0;

    private CharacterController _controller;
    private InputReceiver _inputReceiver;
    private Mover _mover;
    private StoreWithStack _store;

    private void Awake(){
        _controller = GetComponent<CharacterController>();
        _inputReceiver = new InputReceiver();
        _mover = new Mover(_controller, _inputReceiver, speed);
        _store = new StoreWithStack(storeSize, carryTransform, offsetVector, maxLabel);
    }

    private void Update(){
        _inputReceiver.Update();
    }

    private void OnTriggerStay(Collider other){
        var giveInstance = other.GetComponent<GetTrigger>();
        if (giveInstance != null && giveInstance.CanGet && CanPut)
            _store.Put(giveInstance.Get());

        var takeInstance = other.GetComponent<PutTrigger>();
        if (takeInstance == null || !takeInstance.CanPut || !CanGet) return;

        var product = takeInstance.Type == ProductType.All ? _store.Get() : _store.Get(takeInstance.Type);
        takeInstance.Put(product);
    }
}