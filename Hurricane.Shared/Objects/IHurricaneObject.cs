using System;
using System.Collections.Generic;

namespace Hurricane.Shared.Objects
{
    public interface IHurricaneObject
    {
        Guid ObjectGuid { get; }
    }
}