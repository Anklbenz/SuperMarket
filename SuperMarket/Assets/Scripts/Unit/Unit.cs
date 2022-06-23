using Enums;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Unit : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform carryTransform;
    [SerializeField] private GameObject maxLabel;
    [SerializeField] private int basketMaxCount;
    private CharacterController _controller;
    private InputReceiver _inputReceiver;
    private Mover _mover;
    private Basket _basket;

    private void Awake(){
        _controller = GetComponent<CharacterController>();
        _inputReceiver = new InputReceiver();
        _mover = new Mover(_controller, _inputReceiver, speed);
        _basket = new Basket(basketMaxCount, carryTransform, maxLabel);
    }

    private void Update(){
        _inputReceiver.Update();
    }

    private void OnTriggerStay(Collider other){
        var giveInstance = other.GetComponent<IGet>();
        if (giveInstance != null && _basket.CanPut)
            _basket.Put(giveInstance.Get());

        var takeInstance = other.GetComponent<IPut>();
        if (takeInstance == null || !takeInstance.CanPut || !_basket.CanGet) return;

        var product = takeInstance.Type == ProductType.All ? _basket.Get() : _basket.Get(takeInstance.Type);
        takeInstance.Put(product);
    }
}