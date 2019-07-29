using System.Collections.Generic;

namespace CommonIoC
{
    public static class CommonContainer
    {
        private static readonly List<ComponentDescriptor> _componentPool = new List<ComponentDescriptor>();
    }
}