using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Vishnu.Extensions.ArrayType
{
    public static class StuffingExtensions
    {
        /// <summary>
        /// Performs Point to Point Protocol byte stuffing
        /// </summary>
        /// <param name="data">input data</param>
        /// <param name="compareValue">compare value</param>
        /// <param name="stuffValue">stuff value</param>
        /// <param name="superStuffValue">super stuff value</param>
        /// <returns>stuffed data</returns>
        public static byte[] PPPByteStuff(this byte[] data, byte compareValue = 0x7E, byte stuffValue = 0x7D, byte superStuffValue = 0x5D)
        {
            if(data == null || data.Length < 1)
            {
                return data;
            }

            var stuffContent = new List<byte>();
            foreach(var item in data)
            {
                if(item == stuffValue)
                {
                    stuffContent.Add(item);
                    stuffContent.Add(superStuffValue);
                }
                else if(item == compareValue)
                {
                    stuffContent.Add(stuffValue);
                }
                else
                {
                    stuffContent.Add(item);
                }
            }

            return stuffContent.ToArray();
        }

        /// <summary>
        /// De stuff the Point to Point Protocol stuffed data.
        /// </summary>
        /// <param name="data">input data</param>
        /// <param name="compareValue">compare value</param>
        /// <param name="stuffValue">stuff value</param>
        /// <param name="superStuffValue">super stuff value</param>
        /// <returns>original content</returns>
        /// <exception cref="Exception">Raises when input is invalid stuffed value</exception>
        public static byte[] PPPByteDeStuff(this byte[] data, byte compareValue = 0x7E, byte stuffValue = 0x7D, byte superStuffValue = 0x5D)
        {
            if(data == null || data.Length < 1)
            {
                return data;
            }

            var stuffContent = new List<byte>();
            for(int ii=0; ii<data.Length; ii++)
            {
                if(data[ii] == stuffValue)
                {
                    if(ii < data.Length - 1)
                    {
                        if(data[ii + 1] == superStuffValue)
                        {
                            ii++;
                            stuffContent.Add(stuffValue);
                        }
                        else
                        {
                            stuffContent.Add(compareValue);
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid stuffed Content at position : " + ii);
                    }
                }
                else
                {
                    stuffContent.Add(data[ii]);
                }
            }

            return stuffContent.ToArray();
        }


    }
}
