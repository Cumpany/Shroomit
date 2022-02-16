using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{
    public enum Items
    {
        Empty, // dont touch or invenetory breaks
        // add any items after here
        Apple,
        Banana,
        Orange,
        Heal
    }
}
