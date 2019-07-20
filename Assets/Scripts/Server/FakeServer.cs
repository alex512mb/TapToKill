using System;
using System.Collections;
using UnityEngine;

public class FakeServer : MonoBehaviour, IServer
{
    [Tooltip("If value is true then connection will be success")]
    public bool fakeResultConnection = true;
    [Tooltip("How much time will take the fake connection")]
    public float durationConnecting = 1;


    public void Connect(Action<bool> callBack)
    {
        StartCoroutine(StartFakeConnection(callBack));
    }

    private IEnumerator StartFakeConnection(Action<bool> callBack)
    {
        yield return new WaitForSeconds(durationConnecting);
        callBack(fakeResultConnection);
    }

}
