using GraphQL.Types;
using RobotApp.Helpers;
using RobotApp.Database;


namespace RobotApp.Models
{
    public class RobotMutation : ObjectGraphType
    {
        public RobotMutation(ContextServiceLocator contextServiceLocator)
        {
            Name = "RobotMutations";

            Field<RobotType>(
                "createRobot",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<RobotInputType>> { Name = "robot" }
                ),
                resolve: context =>
                {
                    var robot = context.GetArgument<Robot>("robot");
                    return contextServiceLocator.RobotRepository.Add(robot);
                });

            Field<StringGraphType>(
                "updateRobot",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" },
                    new QueryArgument<NonNullGraphType<BooleanGraphType>> { Name = "favourite" }
                ),
                resolve: context =>
                {
                    var name = context.GetArgument<string>("name");
                    var favourite = context.GetArgument<bool>("favourite");
                    
                    var oldbot = contextServiceLocator.RobotRepository.UpdateRobot(name, favourite);
                     
                    return $"The robot with the name: {oldbot.Name} has been successfully updated.";
                });
            Field<StringGraphType>(
                "deleteRobot",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" }),
                resolve: context =>
                {
                    var name = context.GetArgument<string>("name");
                    contextServiceLocator.RobotRepository.DeleteRobot(name);
                    return $"The robot with the name: {name} has been successfully deleted from db.";
                }
            );
        }
    }
}