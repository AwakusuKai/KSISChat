using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FileTransferLibrary
{
    public class DownloadFile
    {
        public string FileName { get; }
        public byte[] FileBytes { get; }

        public DownloadFile(string fileName, byte[] fileBytes)
        {
            FileName = fileName;
            FileBytes = fileBytes;
        }
    }
}