using System;

namespace Equinox.Infra.Email
{
    public class EmailSettings
    {
        public string PrimaryDomain { get; set; }
        public int PrimaryPort { get; set; }
        public string PrimaryEmail { get; set; }
        public string PrimaryPassword { get; set; }
    }
}
