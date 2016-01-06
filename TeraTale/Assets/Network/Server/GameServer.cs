﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using TeraTaleNet;

public abstract class GameServer : NetworkProgramUnity, IDisposable
{
    NetworkAgent _agent = new NetworkAgent();

    protected override void OnStart()
    {
        userName = GetType().Name;

        PacketStream stream;
        ConnectorInfo info;

        stream = _agent.Connect("127.0.0.1", Port.Database);
        stream.Write(new ConnectorInfo(GetType().Name));
        _messenger.Register("Database", stream);
        Console.WriteLine("Database connected.");

        _agent.Bind("127.0.0.1", (Port)Enum.Parse(typeof(Port), GetType().Name), 1);
        stream = _agent.Listen();
        info = (ConnectorInfo)stream.Read().body;
        _messenger.Register(info.name, stream);
        Console.WriteLine(info.name + " connected.");

        foreach (var key in _messenger.Keys)
            StartCoroutine(Dispatcher(key));

        _messenger.Start();
    }

    protected override void OnEnd()
    { }

    IEnumerator Dispatcher(string key)
    {
        while (true)
        {
            while (_messenger.CanReceive(key))
                _messenger.DispatcherCoroutine(key);
            yield return new WaitForSeconds(0);
        }
    }

    protected override void OnUpdate()
    {
        if (Console.KeyAvailable)
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                Stop();
        }
    }

    public void Dispose()
    {
        _messenger.Join();
        _agent.Dispose();
        GC.SuppressFinalize(this);
    }
}