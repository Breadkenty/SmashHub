using System.Reflection;

namespace Smash_Combos.Core
{
    public static class AssemblyUtility
    {
        public static Assembly GetAssembly() => Assembly.GetExecutingAssembly();
    }
}
