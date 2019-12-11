using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceholderAND : Placeholder
{
    public override bool RightPlace()
    {
        bool tmp = gameObject.tag == base.collisionObject.tag;
        //TODO:: if true, schreibe dem Team des Spielers 5 Punkte aufs Konto (gerne auch mit Effekt, wie beim Damage)
        if (tmp) Debug.Log(gameObject.name + ": Thats right! You earn 5 Points!");
        return tmp;
    }
}
