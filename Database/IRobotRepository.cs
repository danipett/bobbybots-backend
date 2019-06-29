
using System.Collections.Generic;
using System.Threading.Tasks;
using RobotApp.Models;

namespace RobotApp.Database
{
    public interface IRobotRepository
    {
        Task<Robot> Get(string name);
        Task<List<Robot>> All(string order, string includedCategories);
        Task<Robot> Add(Robot robot);
        Robot UpdateRobot(string name, bool favourite);
        void DeleteRobot(string name);
    }
}
