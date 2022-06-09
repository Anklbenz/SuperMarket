using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;

public class TakeStore : Store, ITake
{
    public ProductType Type => storeType;
    public bool CanTake => !MaxCount;
}
