using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Enums;
using Random = UnityEngine.Random;

public class Customer : MonoBehaviour
{
   private const int CARRIER_SIZE = 4;

   [SerializeField] private List<Store> stores;
   [SerializeField] private NavMeshAgent navAgent;
   private BehaviorManager _behaviorManager;
   private int _requiredQuantity;

   private void Awake(){
    //   _behaviorManager = new BehaviorManager(stores, navAgent);
   }

   private void Initialize(){
  //    _requiredQuantity = return Random.Range(1, remainingSpace + 1);
   }
   
   private void FixedUpdate(){
 //      _behaviorManager.Update();
   }


}
