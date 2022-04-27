using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SharedKernel.Settings
{
    public class SerilogSettings : ISerilogSettings
    {
        public string SeqServerUrl { get; init; }
        public string LogstashgUrl { get; init; }
    }
}
