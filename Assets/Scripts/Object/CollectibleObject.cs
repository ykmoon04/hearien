using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : ClickableObject
{
    // 수집품
    
    public override void OnClick(){
        Debug.Log("click");
    }
}
