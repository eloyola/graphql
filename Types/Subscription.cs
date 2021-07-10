using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQL.Types
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;

        [Subscribe]
        [Topic]
        public Command OnCommandAdded([EventMessage] Command command) => command;
    }
}