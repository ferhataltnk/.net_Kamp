using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public partial class Class1
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
        public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
        {
            public int Priority { get; set; }  //Öncelik belirlemek için property oluşturduk. 

            public virtual void Intercept(IInvocation invocation)
            {

            }
        }
    }


}
