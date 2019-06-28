using GraphQL;
using GraphQL.Types;

namespace RobotApp.Models
{
    public class RobotSchema : Schema
    {
        public RobotSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<RobotQuery>();
            Mutation = resolver.Resolve<RobotMutation>();
        }
    }
}


 