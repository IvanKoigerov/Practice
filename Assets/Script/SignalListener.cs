using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{

    public Signals sig;
    public UnityEvent signalEv;
    public void OnSignalRaise()
    {
        signalEv.Invoke();
    }

    void OnEnable()
    {
        sig.RegisterListener(this);
    }

    private void OnDisable()
    {
        sig.DeRegisterListener(this);
    }

}
