

using BeanCounter.Domain.Concrete;
namespace BeanCounter.Domain.Helpers
{
    public static class DbConnector
    {
        public static EFDbBeanCounterContext context;

        static  DbConnector()
        {
            context = new EFDbBeanCounterContext();
           
        }
    }
}
