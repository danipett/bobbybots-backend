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
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name" }),
                resolve: context => contextServiceLocator.RobotRepository.Get(context.GetArgument<string>("name")));


            Field<ListGraphType<RobotType>>(
                "robots",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "name_or_score" },
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "includedCategories" }),
                resolve: context => contextServiceLocator.RobotRepository.All(context.GetArgument<string>("name_or_score"),
                context.GetArgument<string>("includedCategories")));
        }
    }
}