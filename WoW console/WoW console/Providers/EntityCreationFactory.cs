using Ninject;
using WoW.CreateCommands.Contracts;
using WoW_console.Contracts;

namespace WoW_console.Providers
{
    public class EntityCreationFactory : IEntityCreationFactory
    {
        private readonly IKernel kernel;

        public EntityCreationFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public ICreateEntity GetEntityCreator(string entityName)
        {
            return this.kernel.Get<ICreateEntity>(entityName);
        }
    }
}
