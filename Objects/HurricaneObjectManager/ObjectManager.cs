using System;
using System.Collections.Generic;
using Hurricane.Shared.Objects;

namespace HurricaneObjectManager
{
    public class ObjectManager : IHurricaneObjectManager
    {
        private readonly Dictionary<Guid, IHurricaneObject> _objects = new Dictionary<Guid, IHurricaneObject>();

        public ObjectManager()
        {
            ObjectGuid = Guid.NewGuid();
        }

        public IHurricaneObject Retrieve(Guid guid)
        {
            if (_objects.ContainsKey(guid))
                return _objects[guid];

            throw new KeyNotFoundException(String.Format("Object [{0}] not found in ObjectManager [{1}]", guid,
                ObjectGuid));
        }

        public void Store(IHurricaneObject obj)
        {
            _objects.Add(obj.ObjectGuid, obj);
        }

        public Guid ObjectGuid { get; private set; }
    }
}