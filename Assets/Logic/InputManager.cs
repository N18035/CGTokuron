using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class InputManager :Singleton<InputManager>
{
    public IObservable<Unit> OnSpace => _space;
    private readonly Subject<Unit> _space = new Subject<Unit>();

    public IObservable<Unit> OnW => _w;
    private readonly Subject<Unit> _w = new Subject<Unit>();

    public IObservable<Unit> OnA => _a;
    private readonly Subject<Unit> _a = new Subject<Unit>();

    public IObservable<Unit> OnS => _s;
    private readonly Subject<Unit> _s = new Subject<Unit>();

    public IObservable<Unit> OnD => _d;
    private readonly Subject<Unit> _d = new Subject<Unit>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _space.OnNext(Unit.Default);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _w.OnNext(Unit.Default);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            _a.OnNext(Unit.Default);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _s.OnNext(Unit.Default);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _d.OnNext(Unit.Default);
        }

    }
}
