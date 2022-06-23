using System;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private Transform carryTransform;
    [SerializeField] private List<Shop> shops;
    [SerializeField] private Shop checkoutShop;
    [SerializeField] private GameObject maxUiLabel;
    private Basket _basket;
    private CustomerLogic _customerLogic;
 
    private void Awake(){
        _basket = new Basket(5, carryTransform, maxUiLabel);
        _customerLogic = new CustomerLogic(navAgent, _basket, shops, checkoutShop);
    }

    private void Start(){
        _customerLogic.Play();
    }

    private void FixedUpdate(){
        _customerLogic.Update();
    }
}