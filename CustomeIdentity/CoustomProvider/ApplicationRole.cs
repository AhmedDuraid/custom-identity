using System;

namespace CustomeIdentity.CoustomProvider
{
    public class ApplicationRole
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
    }
}
