using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class AvatarController : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private Transform carryTransform;
    [SerializeField] private GameObject maxLabel;
    private CharacterController _controller;
    private InputReceiver _inputReceiver;
    private Mover _mover;
    private Carrier _carrier;
   
    private void Awake(){
        _controller = GetComponent<CharacterController>();
        _inputReceiver = new InputReceiver();
        _mover = new Mover(_controller, _inputReceiver, speed);
        _carrier = new Carrier(carryTransform, maxLabel);
    }

    private void Update(){
        _inputReceiver.Update();
    }

    private void OnTriggerStay(Collider other){
        var giveInstance = other.GetComponent<IGive>();
        if (giveInstance != null)
            _carrier.PutIn(giveInstance);
        
        var takeInstance = other.GetComponent<ITake>();
        if (takeInstance != null)
            _carrier.PutOut(takeInstance);
    }
}