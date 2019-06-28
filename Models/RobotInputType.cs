using GraphQL.Types;

namespace RobotApp.Models
{
    public class RobotInputType : InputObjectGraphType
    {
        public RobotInputType()
        {
            Name = "RobotInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<IntGraphType>("score");
            Field<StringGraphType>("image");
            Field<BooleanGraphType>("favourite");
            Field<StringGraphType>("categories");
        }
    }
}
