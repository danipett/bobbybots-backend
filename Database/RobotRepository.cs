using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RobotApp.Models;

namespace RobotApp.Database
{
    public class RobotRepository : IRobotRepository
    {
        private readonly RobotContext _db;

        public RobotRepository(RobotContext db)
        {
            _db = db;
        }
        //Allt relaterat till Queries
        public async Task<Robot> Get(string name)
        {
            return await _db.Robots.FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());
        }

        public async Task<List<Robot>> All()
        {
            return await _db.Robots.ToListAsync();
        }
        //Allt relaterat till Mutations
        public async Task<Robot> Add(Robot robot)
        {
            await _db.Robots.AddAsync(robot);
            await _db.SaveChangesAsync();
            return robot;
        }
        public Robot UpdateRobot(string name)
        {
            var oldbot = _db.Robots.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
            oldbot.Favourite = true;
            _db.Robots.Update(oldbot);

            _db.SaveChangesAsync();
            return oldbot;
        }
        public void DeleteRobot(string name)
        {
            var robot = _db.Robots.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
            _db.Remove(robot);
            _db.SaveChanges();
        }
    }
}
