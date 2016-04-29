using BencodeNET;
using BencodeNET.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTorrent
{
    class Program
    {
        static void Main(string[] args)
        {

            string test = @"C:\Users\dotnet\Downloads\torr.torrent";
            Console.WriteLine("Torrent file path:");
            String torrentfile = test;

            TorrentFile torrent = Bencode.DecodeTorrentFile(torrentfile);
            Console.WriteLine("Info in torrentfile:");
            Console.WriteLine(torrent.Announce);
            foreach (var St in torrent.AnnounceList)
            {
                Console.WriteLine(St.ToString());
            }
            Console.WriteLine(torrent.Comment);
            Console.WriteLine(torrent.CreatedBy);
            Console.WriteLine(torrent.CreationDate);
            Console.WriteLine(torrent.Encoding);

            BDictionary info = (BDictionary) torrent["info"];
            BList files = (BList) info["files"];

            foreach (BDictionary v in files)
            {
                BList path = (BList)v["path"];
         
                Console.WriteLine("Path: {0}, length: {1}" ,path[0], v["length"]);

            }

            Console.ReadLine();
        }
    }
}
