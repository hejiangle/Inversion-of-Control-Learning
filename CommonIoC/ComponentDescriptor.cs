using System;

namespace CommonIoC
{
    public class ComponentDescriptor
    {
        public Type Contract { get; set; }

        public Type Implementation { get; set; }

        public object Instance { get; set; }

        public Lifecycle Lifecycle { get; set; }
    }
}