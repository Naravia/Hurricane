using System;

namespace Hurricane.Shared.Objects
{
    public interface IHurricaneObjectManager : IHurricaneObject
    {
        IHurricaneObject Retrieve(Guid guid);
        void Store(IHurricaneObject obj);
    }
}