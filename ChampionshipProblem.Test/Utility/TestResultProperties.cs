namespace Utility
{
    public class TestResultProperties
    {
        public string Country { get; set; }

        public string LeagueName { get; set; }

        public string Season { get; set; }

        public int Stage { get; set; }

        public int TeamNumber { get; set; }

        public bool Expected { get; set; }

        public bool Returned { get; set; }

        public bool IsTrue { get; set; }

        public long ComputeTime { get; set; }

        public override string ToString()
        {
            return $"{Country},{LeagueName},{Season},{Stage},{TeamNumber},{Expected},{Returned},{IsTrue},{ComputeTime}";
        }
    }
}
