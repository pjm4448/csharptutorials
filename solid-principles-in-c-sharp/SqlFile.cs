using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solid_principles_in_c_sharp
{
    public interface IReadableSqlFile
    {
        string LoadText();
    }
    public interface IWritableSqlFile
    {
        void SaveText();
    }
    public class SqlFile : IReadableSqlFile, IWritableSqlFile
    {
        public string LoadText()
        {
            return "SQL file loaded";
        }
        public void SaveText()
        {
            Console.WriteLine("SQL file saved");
        }
    }
}
