
using System.Collections.Generic;
using System.Threading.Tasks;
using RobotApp.Models;

namespace RobotApp.Database
{
    public interface IRobotRepository
    {
        Task<Robot> Get(string name);
        Task<List<Robot>> All();
        Task<Robot> Add(Robot robot);
        Robot UpdateRobot(string name);
        void DeleteRobot(string name);
    }
}
