
using BloodBankDAL.Repository.Implementation;
using BloodBankDAL.Repository.Implementation.Initialization;
using BloodBankDAL.Repository.Implementation.Query;
using BloodBankDAL.Repository.Implementation.Report;
using BloodBankDAL.Repository.Implementation.Transaction;
using BloodBankDAL.Repository.Interface;
using BloodBankDAL.Repository.Interface.Initialization;
using BloodBankDAL.Repository.Interface.Query;
using BloodBankDAL.Repository.Interface.Report;
using BloodBankDAL.Repository.Interface.Transaction;
using Ninject.Web.Common.WebHost;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BloodBank.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(BloodBank.App_Start.NinjectWebCommon), "Stop")]

namespace BloodBank.App_Start
{
    using System;
    using System.Web;
    using BloodBankDAL.Repository.Implementation.Menu;
    using BloodBankDAL.Repository.Interface.Menu;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()

        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                kernel.Bind<IMenu>().To<MenuRepository>();
                kernel.Bind<IT12244>().To<T12244Repository>();
                kernel.Bind<ILogin>().To<LoginRepository>();
                kernel.Bind<IError>().To<ErrorRepository>();
                kernel.Bind<IT12204>().To<T12204Repository>();
                kernel.Bind<IT12214>().To<T12214Repository>();
                kernel.Bind<IT12068>().To<T12068Repository>();
                kernel.Bind<IT12202>().To<T12202Repository>();
                kernel.Bind<IT12201>().To<T12201Repository>();
                kernel.Bind<RI12204>().To<R12204Repository>();
                kernel.Bind<IT12235>().To<T12235Repository>();
                kernel.Bind<RI12201>().To<R12201Repository>();
                kernel.Bind<IT12236>().To<T12236Repository>();
                kernel.Bind<IT13054>().To<T13054Repository>();
                kernel.Bind<IT12245>().To<T12245Repository>();
                kernel.Bind<IT12250>().To<T12250Repository>();
                kernel.Bind<IT12252>().To<T12252Repository>();
                kernel.Bind<IT12325>().To<T12325Repository>();
                kernel.Bind<IT12328>().To<T12328Repository>();
                kernel.Bind<IT12241>().To<T12241Repository>();
                kernel.Bind<IT12232>().To<T12232Repository>();
                kernel.Bind<IT12349>().To<T12349Repository>();
                kernel.Bind<IT12233>().To<T12233Repository>();
                kernel.Bind<IR12016>().To<R12016Repository>();
                kernel.Bind<IT01004>().To<T01004Repository>();
                kernel.Bind<IT12132>().To<T12132Repository>();
                kernel.Bind<IT12199>().To<T12199Repository>();
                kernel.Bind<IT12033>().To<T12033Repository>();
                kernel.Bind<IT12011>().To<T12011Repository>();
                kernel.Bind<IT12246>().To<T12246Repository>();
                kernel.Bind<IT12300>().To<T12300Repository>();
                kernel.Bind<IT12281>().To<T12281Repository>();
                kernel.Bind<IT12332>().To<T12332Repository>();
                kernel.Bind<IT12003>().To<T12003Repository>();
                kernel.Bind<IT12301>().To<T12301Repository>();
                kernel.Bind<IT12337>().To<T12337Repository>();
                kernel.Bind<IT12338>().To<T12338Repository>();
                kernel.Bind<IT12087>().To<T12087Repository>();
                kernel.Bind<IT12207>().To<T12207Repository>();
                kernel.Bind<IT12302>().To<T12302Repository>();
                kernel.Bind<IT12309>().To<T12309Repository>();
                kernel.Bind<IT12262>().To<T12262Repository>();
                kernel.Bind<IT12263>().To<T12263Repository>();
                kernel.Bind<IT12264>().To<T12264Repository>();
                kernel.Bind<IT12265>().To<T12265Repository>();
                kernel.Bind<IT12266>().To<T12266Repository>();
                kernel.Bind<IT12091>().To<T12091Repository>();
                kernel.Bind<IQ03001>().To<Q03001Repository>();
                kernel.Bind<IQ12025>().To<Q12025Repository>();
                kernel.Bind<IR12025>().To<R12025Repository>();
                kernel.Bind<IR12302>().To<R12302Repository>();
                kernel.Bind<IT01009>().To<T01009Repository>();
                kernel.Bind<IQ12012>().To<Q12012Repository>();
                kernel.Bind<IT12304>().To<T12304Repository>();
                kernel.Bind<IR12304>().To<R12304Repository>();
                kernel.Bind<IR12006>().To<R12006Repository>();
                kernel.Bind<IR12260>().To<R12260Repository>();
                kernel.Bind<IQ12200>().To<Q12200Repository>();
                kernel.Bind<IQ12252>().To<Q12252Repository>();
                kernel.Bind<IQ12017>().To<Q12017Repository>();
                kernel.Bind<IQ12018>().To<Q12018Repository>();
                kernel.Bind<IQ12207>().To<Q12207Repository>();
                kernel.Bind<IQ12263>().To<Q12263Repository>();
                kernel.Bind<IQ12352>().To<Q12352Repository>();

                kernel.Bind<IT12322>().To<T12322Repository>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }
    }


}
