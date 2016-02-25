using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Innoria.Demo.Base64
{
    public class Base64Algorithm
    {
        private static readonly string Base64Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
        public static string Encode(byte[] data)
        {
            string bits = string.Join("", data.Select(f => Convert.ToString(f, 2).PadLeft(8, '0')));
            var bitCount = bits.Length;
            string padding = "";
            if (bitCount % 6 == 2)
            {
                bits += "0000";
                padding = "==";
            }
            else if (bitCount % 6 == 4)
            {
                bits += "00";
                padding = "=";
            }
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < bits.Length / 6; i++)
            {
                string block6 = string.Join("", bits.Skip(i * 6).Take(6));
                int idx = Convert.ToInt32(block6, 2);
                output.Append(Base64Letters[idx]);
            }
            output.Append(padding);
            return output.ToString();
            //for (int i = 0; i < data.Length; i++)
            //{
            //    /*
            //    Example: {Innoria} = 0100.1001 0110.1110 0110.1110 0110.1111 0111.0010 0110.10010 0110.0001
            //    data[i] = 0100.1001
            //                        &
            //      {252} = 1111.1100
            //             -----------
            //              0100.10|00

            //      =========================

            //              0100.1001
            //                        &
            //      {252} = 0000.0011
            //             -----------
            //              0000|0001
                          
            //    */
            //}
        }

        public static string EncodeFromFile(string fileName)
        {
            var bytes = ReadFromFile(fileName);
            return Encode(bytes);
        }

        private static byte[] ReadFromFile(string fileName)
        {
            return File.ReadAllBytes(fileName);
        }
    }

    public class DropableObject
    {
        System.Windows.Forms.IDataObject data;
    }
}
