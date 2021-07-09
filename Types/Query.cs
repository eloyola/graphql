namespace CommanderGQL.Types
{
    using System.Linq;
    using CommanderGQL.Data;
    using CommanderGQL.Models;
    using HotChocolate;
    using HotChocolate.Data;

    public class Query
    {
        /*
        public IQueryable<Platform> GetPlatform([Service] AppDbContext context)
        {
            return context.Platforms;
        }
        Service Lifetimes
        singleton: same for every request
        scoped: created once per client request
        trasient: new instance created every time
        */

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }
        
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Command> GetCommands([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}
