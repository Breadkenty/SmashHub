using System.Reflection;

namespace SmashHub.Core
{
    public static class AssemblyUtility
    {
        public static Assembly GetAssembly() => Assembly.GetExecutingAssembly();
    }
}
