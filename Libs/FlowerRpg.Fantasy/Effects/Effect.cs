﻿using FlowerRpg.Effects;
using FlowerRpg.Stats;

namespace FlowerRpg.Fantasy.Effects;

public abstract class Effect(Stat stat, ModifierType modifierType) : IEffect
{
    public float Potency { get; set; }
    public Stat Data => stat;

    public abstract void Apply();

    public abstract void Remove();
}