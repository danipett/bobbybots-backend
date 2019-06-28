using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace RobotApp.Models
{
    public class Robot
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public string Image { get ; set; }
        public string[] Categories { get; set; }
        public bool Favourite { get; set; }
    }
}