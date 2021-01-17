using System.Reflection;

namespace SmashCombos.Core
{
    public static class AssemblyUtility
    {
        public static Assembly GetAssembly() => Assembly.GetExecutingAssembly();
    }
}
