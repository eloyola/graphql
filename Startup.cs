namespace CommanderGQL
{
    using CommanderGQL.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using GraphQL.Server.Ui.Voyager;
    using CommanderGQL.Types;

    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer((Configuration.GetConnectionString("CommandCnStr"))));
            services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddSubscriptionType<Subscription>()
            .AddType<PlatformType>()
            .AddType<CommandType>()
            .AddFiltering()
            .AddSorting()
            .AddInMemorySubscriptions();
            // .AddProjections();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new VoyagerOptions {
                GraphQLEndPoint="/graphql"                
            }, "/graphql-voyager");
        }
    }
}
