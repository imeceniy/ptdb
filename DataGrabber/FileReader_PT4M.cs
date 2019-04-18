using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrabber
{
    public class FileReader_PT4M
    {
        public Dictionary<int, Dictionary<int, DataSection_PT4M>> Things;

        public void ReadFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path), "Path can not be empty!");
            }

            Things = new Dictionary<int, Dictionary<int, DataSection_PT4M>>();

            var file = File.ReadAllLines(path, Encoding.GetEncoding(866));
            var lines = file.Skip(5);
            int thing = int.MinValue;
            foreach (var line in lines)
            {
                var words = line.Replace('.', ',').Split(' ', '\t').Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToList();
                if (words.Count < 11)
                    continue;

                if (words.Count == 13)
                {
                    if (!int.TryParse(words[0], out thing))
                    {
                        throw new ApplicationException($"Can't parse first element as int. Line: {line}");
                    }
                    Things.Add(thing, new Dictionary<int, DataSection_PT4M>());
                    words.RemoveAt(0);
                }

                if (thing == int.MinValue)
                {
                    throw new ApplicationException($"Can't proceed! Got section without thing. Line: {line}");
                }

                if (!int.TryParse(words[0], out int section))
                {
                    throw new ApplicationException($"Can't parse the second element as int. Line: {line}");
                }
                words.RemoveAt(0);
                Things[thing].Add(section, DataSection_PT4M.Create(words[0], words[1], words[2], words[3], words[4], words[5], words[6], words[7], words[8], words[9], words[10]));
            }
        }
    }
}