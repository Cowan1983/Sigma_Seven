using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Seven_Test
{
    //This class could be Static, or a Singleton implementation

    class SigmaSevenTest
    {
        /// <summary>
        /// The only public function in the class
        /// </summary>
        public void RunSigmaSevenTest()
        {
            //Call the funtion to delete designated UDN records from the source file.
            //Pass in the list of UDNs to be deleted returned by the "GetDeletionUDNs()" function
            RemoveUDNsFromFile(GetDeletionUDNs());
        }
        
        /// <summary>
        /// Read the "FeaturesToDelete" file and put the UND numbers into a List<string>
        /// This List will be interogated later.
        /// </summary>
        /// <returns></returns>
        private List<string> GetDeletionUDNs()
        {
            //We will work with the assumption that the file with the UDN numbers
            //to be deleted from the main file has a set file location and name. 
            //The file path and name could be passed into the function
            var uDNDeletionFile = File.ReadAllLines("FeaturesToDelete.txt");

            //Turn this file into a List<string>
            List<string> UDNsToDelete = new List<string>(uDNDeletionFile);

            //Pass back the list
            return UDNsToDelete;

        }

        private void RemoveUDNsFromFile(List<string> UDNsToDelete)
        {
            //We will work with the assumption that the file the UDN numbers are
            //to be deleted from has set file location and name.
            //The file path and name could be passed into the function
            var unfilteredFile = File.ReadAllLines("Features.txt");
            //Reading the whole file will be memory hungry, but will make processing fast(er)
            //The alternative being to read/write the file line-by-line from/to the disc. 

            //Create our file stream for writing out the filtered file
            using (var outputFileStream = new StreamWriter("Filtered.txt")) //A "Using" block is a safe way to handle file streams
            {
                //Read each line in the unfiltered file
                foreach (string thisLine in unfilteredFile)
                {
                    //See if the UDN for this line is in the list of UDNs to be deleted.
                    if (!UDNsToDelete.Contains(ExtractUDNFromLine(thisLine)))
                    {
                        //If the UDN was not in the list of UDNs to be deleted, write it to the filtered list file
                        outputFileStream.WriteLine(thisLine);
                    }
                }
            }

        }

        /// <summary>
        /// Extract the first section of a string, up to the first occurence of a ',' (a comma)
        /// </summary>
        /// <param name="fileLine">A string with a UDN as the first item, followed by a comma</param>
        /// <returns></returns>
        private string ExtractUDNFromLine(string fileLine)
        {
            //This assumes that the UDN is the first value in the file, and that the value delimiter is a ',' and not
            //some other character (like a '_' or '|').
            return fileLine.Substring(0, fileLine.IndexOf(','));
        }
    }
}
