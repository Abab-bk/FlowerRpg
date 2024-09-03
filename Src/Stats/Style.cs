/* Original code[1] Copyright (c) 2022 Shane Celis[2]
   Licensed under the MIT License[3]

   This comment generated by code-cite[3].

   [1]: https://github.com/shanecelis/SeawispHunter.RolePlay.Attributes
   [2]: https://twitter.com/shanecelis
   [3]: https://opensource.org/licenses/MIT
   [4]: https://github.com/shanecelis/code-cite
*/

#if NET7_0_OR_GREATER
using System.Numerics;
#endif
using System;

namespace FlowerRpg.Stats {

/** This stat class represents the style of stat altering presented by Daniel
    Sidhion in this article[1].

    Currently this class only works with float and int but other numerical types
    can be easily added.

    [1]: https://gamedevelopment.tutsplus.com/tutorials/using-the-composite-design-pattern-for-an-rpg-attributes-system--gamedev-243
*/
public class SidhionStat<T> : ModifiableValue<T>
#if NET7_0_OR_GREATER
  where T : INumber<T>
#endif
{
  public readonly IModifiableValue<T> rawBonusesPlus = new ModifiableValue<T>();
  public readonly IModifiableValue<T> rawBonusesTimes = new ModifiableValue<T>(one);
  public readonly IModifiableValue<T> finalBonusesPlus = new ModifiableValue<T>();
  public readonly IModifiableValue<T> finalBonusesTimes = new ModifiableValue<T>(one);
  public SidhionStat(T initialValue) : base(initialValue) {
    // value = ((baseValue + rawBonusesPlus) * rawBonusesTimes + finalBonusesPlus) * finalBonusesTimes
    modifiers.Add(100, Modifier.Plus(rawBonusesPlus));
    modifiers.Add(200, Modifier.Times(rawBonusesTimes));
    modifiers.Add(300, Modifier.Plus(finalBonusesPlus));
    modifiers.Add(400, Modifier.Times(finalBonusesTimes));
  }

#if NET7_0_OR_GREATER
  private static T one => T.One;
#else
  private static T one => Modifier.GetOp<T>().one;
#endif
}

public class Stat<T> : ModifiableValue<T>
#if NET7_0_OR_GREATER
  where T : INumber<T>
#endif
{
  public enum Priority {
    Flat = 100,
    PercentAdd = 200,
    PercentTimes = 300
  };

  public readonly IModifiableValue<T> flat = new ModifiableValue<T>();
  public readonly IModifiableValue<T> percentAdd = new ModifiableValue<T>(one);
  public readonly IModifiableValue<T> percentTimes = new ModifiableValue<T>(one);
  public Stat(T initialValue) : base(initialValue) {
    modifiers.Add((int) Priority.Flat, Modifier.Plus(flat));
    modifiers.Add((int) Priority.PercentAdd, Modifier.Times(percentAdd));
    modifiers.Add((int) Priority.PercentTimes, Modifier.Times(percentTimes));
  }

#if NET7_0_OR_GREATER
  private static T one => T.One;
#else
  private static T one => Modifier.GetOp<T>().one;
#endif
}
}
