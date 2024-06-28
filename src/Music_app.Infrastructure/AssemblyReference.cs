using System.Reflection;

namespace Music_app.Infrastructure
{
    public static class AssemblyReference
    {
        public static readonly Assembly assembly = typeof(AssemblyReference).Assembly;
    }
}