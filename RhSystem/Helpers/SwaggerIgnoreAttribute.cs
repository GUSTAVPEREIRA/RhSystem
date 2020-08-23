namespace RhSystem.Helpers
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class SwaggerIgnoreAttribute : Attribute
    {
    }
}
