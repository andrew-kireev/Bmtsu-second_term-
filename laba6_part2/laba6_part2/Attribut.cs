using System;

namespace laba6_part2
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple =
 false, Inherited = false)]
    public class NewAttribute : Attribute
    {
        public NewAttribute() { }
        public NewAttribute(string DescriptionParam)
        {
            Description = DescriptionParam;
        }
        public string Description { get; set; }
    }
}

