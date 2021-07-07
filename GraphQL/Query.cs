
namespace CommanderGQL.GraphQL
{
    using System.Linq;
    using CommanderGQL.Data;
    using CommanderGQL.Models;
    using HotChocolate;

    public class Query
    {
        public IQueryable<Platform> GetPlatform([Service] AppDbContext context)
        {
            return context.Platforms;
        }
    }
}