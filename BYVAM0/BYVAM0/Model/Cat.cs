﻿namespace BYVAM0.Model
{
    [Flags]
    internal enum Cat
    {
        Tabby = 0b_000_000,
        Void = 0b_000_010,
        Orange = 0b_000_100,
        Calico = 0b_001_000,
    }
}