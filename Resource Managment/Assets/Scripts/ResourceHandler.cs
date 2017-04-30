using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHandler : MonoBehaviour
{
    [SerializeField]
    private int _gold;
    
    //Properties
    public int Gold
    {
        get { return _gold; }
        set
        {
            _gold = value;
            _gold = Mathf.Clamp(_gold, 0, _gold);
        }
    }
}
