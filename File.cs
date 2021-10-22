using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipWar
{
    public class File
    {
        public void CreateToFile()
        {
            string folderName = @"D:\";
            string pathString = Path.Combine(folderName, "Log");     

     
            System.IO.Directory.CreateDirectory(pathString);

            string fileName = Path.GetRandomFileName();

            pathString =Path.Combine(pathString, fileName);
        }

    
    public void AddToFile(String str)
        {
                StreamWriter sw = new StreamWriter("D:\\Log.txt");
                sw.WriteLine(str);
                sw.Close();
        }
    }

}
