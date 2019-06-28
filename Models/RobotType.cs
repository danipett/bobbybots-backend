using GraphQL.Types;
using RobotApp.Helpers;
using RobotApp.Database;
using RobotApp.Models;

namespace RobotApp.Models
{
    public class RobotType : ObjectGraphType<Robot>
    {
        public RobotType(ContextServiceLocator contextServiceLocator)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Image);
            Field(x => x.Favourite);
            Field(x => x.Score);
            Field(x => x.Categories);
        }
    }
}
