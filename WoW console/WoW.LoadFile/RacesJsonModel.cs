using System.Collections.Generic;

namespace WoW.LoadFile
{
    public class RacesJsonModel
    {
        public string Name { get; set; }

        public int FactionId { get; set; }

        public string Language { get; set; }

        public string Location { get; set; }

        public string Capital { get; set; }

        public string Mount { get; set; }

        public IList<string> Classes { get; set; }
    }
}
