//
//
//

namespace MarseMover
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public interface IRoverActivity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rover"></param>
        /// <param name="relativeDirectionCommand"></param>
        /// <returns></returns>
        bool IsTurned(Rover rover, char relativeDirectionCommand);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rover"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        bool IsMoved(Rover rover,Area area);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roverCommand"></param>
        /// <param name="rover"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        bool IsCommandExecuted(char roverCommand, Rover rover, Area area);
    }

}
