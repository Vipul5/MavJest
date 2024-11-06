namespace ChatInteractionService.Helper
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyExampleAttribute: Attribute
    {
        public string ExampleValue { get; }

        public PropertyExampleAttribute(string exampleValue)
        {
            ExampleValue = exampleValue;
        }
    }
}
