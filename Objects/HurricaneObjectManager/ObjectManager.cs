using System;
using System.Collections.Generic;
using Hurricane.Shared.Objects.Interfaces;

namespace HurricaneObjectManager
{
    public class ObjectManager : IHurricaneObjectManager
    {
        private readonly Dictionary<Guid, IHurricaneObject> _objects = new Dictionary<Guid, IHurricaneObject>();

        public ObjectManager()
        {
            this.ObjectGuid = Guid.NewGuid();
        }

        public IHurricaneObject Retrieve(Guid guid)
        {
            if (this._objects.ContainsKey(guid))
                return this._objects[guid];

            throw new KeyNotFoundException(String.Format("Object [{0}] not found in ObjectManager [{1}]", guid,
                this.ObjectGuid));
        }

        public void Store(IHurricaneObject obj)
        {
            this._objects.Add(obj.ObjectGuid, obj);
        }

        public Guid ObjectGuid { get; private set; }
    }
}