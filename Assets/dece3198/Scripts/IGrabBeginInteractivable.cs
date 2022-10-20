using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabBeginInteractivable
{
    public bool IsGrabed
    {
        get;
        set;
    }
    public void GrabBegin(GameObject grabberObj);
    public void GrabEnd(GameObject grabberObj);
}
