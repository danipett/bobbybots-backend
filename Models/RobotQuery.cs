using GraphQL.Types;
using RobotApp.Database;
using RobotApp.Helpers;


namespace RobotApp.Models
{
    public class RobotQuery : ObjectGraphType
    {
        public RobotQuery(ContextServiceLocator contextServiceLocator)
        {
            Field<RobotType>(
                "robot",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "name" }),
                resolve: context => contextServiceLocator.RobotRepository.Get(context.GetArgument<string>("name")));


            Field<ListGraphType<RobotType>>(
                "robots",
                resolve: context => contextServiceLocator.RobotRepository.All());
        }
    }
}