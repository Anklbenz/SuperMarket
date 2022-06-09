using System;
using UnityEngine;
using Enums;

public abstract class Product : MonoBehaviour
{
  public ProductType Type => type;
  [SerializeField] protected ProductType type;
}