﻿namespace FlowerRpg.Combat;

public struct Attack
{
    public ICollection<Damage> Damages { get; set; } = new List<Damage>(); 

    public Attack () { }
    public Attack(ICollection<Damage> damages)
    {
        Damages = damages;
    }
}