using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharptests
{

    public class Book
    {
        public Book()
        {
            CreatedTime = DateTime.Now;
        }
        public DateTime CreatedTime { get; set; }
        public string BookName { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
    }

    public static class UtilityExt
    {
        ///<summary>
        /// Add "N" number of objects to the source list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="emptySource"></param>
        /// <param name="number">Number of elements to add</param>
        public static void AddNObjectsToCollection<T>(this List<T> emptySource, int number)
          where T : new()
        {
            emptySource.AddRange(Enumerable.Repeat(new T(), number));
        }
        ///<summary>
        /// Returns the collection which contains "N" numbers of elements of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="emptySource"></param>
        /// <param name="number">Number of elements to return</param>
        /// <returns></returns>
        public static IList<T> GenerateSpecificNumberOfCollection<T>(this IEnumerable<T> emptySource, int number)
          where T : new()
        {
            return Enumerable.Repeat(new T(), number).ToList();
        }
    }

}
