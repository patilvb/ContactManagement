using ContactManagement.Data;
using ContactManagement.Services;
using Unity;
using Unity.Mvc5;

namespace ContactManagement.Web.DIContainer
{
    public class Bootstrapper
    {
        public static UnityDependencyResolver GetUnityDependencyResolver()
        {
            var container = BuildUnityContainer();
            return new UnityDependencyResolver(container);
        }

        public static UnityResolver GetUnityResolver()
        {
            var container = BuildUnityContainer();
            return new UnityResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<ICustomerRepositary, CustomerRepositary>();           
            return container;
        }
       
    }
}