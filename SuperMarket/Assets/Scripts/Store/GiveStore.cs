using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveStore : Store, IGive
{
    public bool CanGive => Count > 0;
}
