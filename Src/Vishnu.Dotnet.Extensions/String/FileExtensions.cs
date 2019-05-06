using System;
using System.IO;
using System.Text;

namespace Vishnu.Extensions.String
{
    /// <summary>
    /// String file extensions
    /// </summary>
    public static class FileExtension
    {
        /// <summary>
        /// Copy file from source to destination
        /// </summary>
        /// <param name="source">source file</param>
        /// <param name="destination">destination file</param>
        /// <returns>true or false</returns>
        public static bool CopyFile(this string source, string destination)
        {
            bool result = false;
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException(source);
            }

            if (string.IsNullOrEmpty(destination))
            {
                throw new ArgumentNullException(destination);

            }

            if (!File.Exists(source))
            {
                throw new FileNotFoundException(source);
            }

            try
            {
                File.Copy(source, destination);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// Delete file
        /// </summary>
        /// <param name="source">file path</param>
        /// <returns>true or false</returns>
        public static bool DeleteFile(this string source)
        {
            bool result = false;
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException(source);
            }


            if (!File.Exists(source))
            {
                throw new FileNotFoundException(source);
            }

            try
            {
                File.Delete(source);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// Rename a file
        /// </summary>
        /// <param name="source">source file</param>
        /// <param name="destination">destination file</param>
        /// <returns>true or false</returns>
        public static bool RenameFile(this string source, string destination)
        {
            bool result = false;
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException(source);
            }

            if (string.IsNullOrEmpty(destination))
            {
                throw new ArgumentNullException(destination);

            }

            if (!File.Exists(source))
            {
                throw new FileNotFoundException(source);
            }

            try
            {
                File.Move(source, destination);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// Check if file exists
        /// </summary>
        /// <param name="source">file path</param>
        /// <returns>true or false</returns>
        public static bool IsExists(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                throw new ArgumentNullException(source);
            }

            return File.Exists(source);
        }

        /// <summary>
        /// Read file content in specified path
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>contents in string</returns>
        public static string Read(this string path)
        {
            return File.ReadAllText(path);
        }

        /// <summary>
        /// Read file content with encoding
        /// </summary>
        /// <param name="path">file path</param>
        /// <param name="encoding">encoding</param>
        /// <returns>contents in string</returns>
        public static string Read(this string path, Encoding encoding)
        {
            return File.ReadAllText(path, encoding);
        }
    }
}
