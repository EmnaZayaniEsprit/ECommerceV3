using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using ECommerce.Service;
using ECommerce.Data.Infrastructure;

namespace ECommerce.GUI.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            
            container.RegisterType<IUnitOfWork, UnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType<IDatabaseFactory, DatabaseFactory>(new PerRequestLifetimeManager());
            container.RegisterType<IProductRepository, ProductRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IAddressRepository, AddressRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ICategoryRepository, CategoryRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ICommisionRepository, CommisionRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ICreditCardRepository, CreditCardRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IGouvernoratRepository, GouvernoratRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IOrderItemRepository, OrderItemRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IOrderRepository, OrderRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IPictureRepository, PictureRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IProductItemRepository, ProductItemRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IProductItemSupplierRepository, ProductItemSupplierRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IPromotionRepository, PromotionRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IReclamationRepository, ReclamationRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IRecommendationRepository, RecommendationRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IReviewRepository, ReviewRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IShoppingCartRepository, ShoppingCartRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new PerRequestLifetimeManager());
            container.RegisterType<IProductService, ProductService>(new PerRequestLifetimeManager());
            container.RegisterType<IProductSupplierService, ProductSupplierService>(new PerRequestLifetimeManager());
            container.RegisterType<ICategorySupplierService, CategorySupplierService>(new PerRequestLifetimeManager());
            container.RegisterType<IPromotionSupplierService, PromotionSupplierService>(new PerRequestLifetimeManager());
            container.RegisterType<IUserSupplierService, UserSupplierService>(new PerRequestLifetimeManager());
            container.RegisterType<IPictureSupplierService, PictureSupplierService>(new PerRequestLifetimeManager());

        }
    }
}
