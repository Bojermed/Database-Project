using System.Collections.Generic;

namespace WoW.LoadFile
{
    public class ClassesJsonModel
    {
        public ClassesJsonModel()
        {
            this.Races = new List<string>();
        }

        public string Name { get; set; }

        public int ResourceId { get; set; }

        public string Lore { get; set; }

        public IList<string> Races { get; set; }

    }
}
