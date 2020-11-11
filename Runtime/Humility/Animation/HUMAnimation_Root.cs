using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class HUMAnimation
{
    public static Data.Create Create(this Animator animator)
    {
        return new Data.Create(animator);
    }
}
