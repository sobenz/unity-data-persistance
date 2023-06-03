using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour, IBrick
{
    private int _pointValue;
    private UnityEvent<int> _onDestroyed = new UnityEvent<int>();

    public UnityEvent<int> onDestroyed
    {
        get => _onDestroyed;
        set => _onDestroyed = value;
    }

    public int PointValue
    {
        get => _pointValue;
        set => _pointValue = value;
    }

    void Start()
    {
        var renderer = GetComponentInChildren<Renderer>();

        MaterialPropertyBlock block = new MaterialPropertyBlock();
        SetBlockColor(block);

        renderer.SetPropertyBlock(block);
    }

    private void OnCollisionEnter(Collision other)
    {
        AttemptDestoryBrick();
    }

    protected virtual void AttemptDestoryBrick()
    {
        onDestroyed.Invoke(PointValue);

        //slight delay to be sure the ball have time to bounce
        Destroy(gameObject, 0.2f);
    }

    protected virtual void SetBlockColor(MaterialPropertyBlock block)
    {
        switch (PointValue)
        {
            case 1:
                block.SetColor("_BaseColor", Color.green);
                break;
            case 2:
                block.SetColor("_BaseColor", Color.yellow);
                break;
            case 5:
                block.SetColor("_BaseColor", Color.blue);
                break;
            default:
                block.SetColor("_BaseColor", Color.red);
                break;
        }
    }
}

public interface IBrick
{
    int PointValue { get; set; }
    UnityEvent<int> onDestroyed { get; set; }
}
