using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
        //Everything related to Queries
        //Get Robot by name
        public async Task<Robot> Get(string name)
        {
            return await _db.Robots.FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());
        }

        //Get all Robots, sorted by name or score depending on passed argument and only including
        //the categories passed as an argument in the form of a comma-delimited string
        public async Task<List<Robot>> All(string order, string includedCategories)
        {
            var robots = from r in _db.Robots select r;
            Console.WriteLine(includedCategories);
            if(order=="name")
            {
                robots = robots.OrderByDescending(r => r.Favourite).ThenBy(r => r.Name);
            }
            if(order=="score")
            {
                robots = robots.OrderByDescending(r => r.Favourite).ThenByDescending(r => r.Score);
            }
            List<string> includedCategoriesList = includedCategories.Split(",").ToList();
            robots = robots.Where(r => includedCategoriesList.Any(s => r.Categories.Contains(s)));
            return await robots.AsNoTracking().ToListAsync();
        }
        
        //Everything related to Mutations
        //Add a new Robot
        public async Task<Robot> Add(Robot robot)
        {
            await _db.Robots.AddAsync(robot);
            await _db.SaveChangesAsync();
            return robot;
        }

        //Update Robot
        public Robot UpdateRobot(string name, bool favourite)
        {
            var oldbot = _db.Robots.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
            oldbot.Favourite = favourite;
            _db.Robots.Update(oldbot);

            _db.SaveChangesAsync();
            return oldbot;
        }

        //Delete a Robot by name
        public void DeleteRobot(string name)
        {
            var robot = _db.Robots.FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
            _db.Remove(robot);
            _db.SaveChanges();
        }
    }
}
