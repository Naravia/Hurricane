using System;
using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Components
{
    /// <summary>
    /// Defines a HurricaneComponent - a server forming part of Hurricane
    /// 
    /// Call order: Initialise(), Boot(), Tick() while server is running, Shutdown()
    /// </summary>
    public interface IHurricaneComponent : IHurricaneObject, IOutput
    {
        /// <summary>
        /// Verifies all instances are instantiated correctly and throws a relevant exception if not
        /// </summary>
        /// <returns></returns>
        void Initialise();

        /// <summary>
        /// Registers internal handlers, loads configuration data for component, loads resources needed
        /// </summary>
        void Boot();

        /// <summary>
        /// Unregisters internal handlers, destroys all instantiated objects
        /// 
        /// After Shutdown() completes, component is in the state it was in after Initialise() was called
        /// </summary>
        void Shutdown();

        /// <summary>
        /// Runs a single tick of the server's logic loop
        /// 
        /// This is called frequently and DOES NOT BLOCK! This means tickrate can be used to quickly judge component performance
        /// All network related code is in a completely seperate thread and calls back to static methods
        /// </summary>
        /// <param name="timeSinceLastTick">Amount of time that has passed since Tick() was last called</param>
        void Tick(TimeSpan timeSinceLastTick);
    }
}