using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongBrick : Brick
{
    private int _health = 2;

    protected override void AttemptDestoryBrick()
    {
        _health--;
        if (_health == 1)
        {
            var renderer = GetComponentInChildren<Renderer>();
            var rendererProperties = new MaterialPropertyBlock();
            renderer.GetPropertyBlock(rendererProperties);
            var color = rendererProperties.GetColor("_BaseColor");
            color.r = color.r * 2f;
            color.g = color.g * 2f;
            color.b = color.b * 2f;
            rendererProperties.SetColor("_BaseColor", color);
            renderer.SetPropertyBlock(rendererProperties);

        }
        if (_health <= 0)
        {
            base.AttemptDestoryBrick();
        }
    }

    protected override void SetBlockColor(MaterialPropertyBlock block)
    {
        base.SetBlockColor(block);
        var color = block.GetColor("_BaseColor");
        color.r = color.r * 0.5f;
        color.g = color.g * 0.5f;
        color.b = color.b * 0.5f;
        block.SetColor("_BaseColor", color);
    }
}
