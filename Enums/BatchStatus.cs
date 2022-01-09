using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Enums
{
    public static class BatchStatus
    {
        public const string Open = "Open";
        public const string Processing = "Processing";
        public const string Finished = "Finished";
        public const string Closed = "Closed";
        public const string Paused = "Paused";
        public const string Killed = "Killed";
    }
    public static class BatchDataSetStatus
    {
        public const string Error = "Error";
        public const string Open = "Open";
        public const string Processing = "Processing";
        public const string Finished = "Finished";
        public const string Closed = "Closed";
        public const string Paused = "Paused";
        public const string Killed = "Killed";
    }
}
