using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Cats_API.Models
{
    public static class ExtMethods
    {
        /// <summary>
        /// <para>
        /// Searches a DbSet object for the given entity object matched by the provided matching property.<br />
        /// Returns either the found object or the given object.
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="obj"></param>
        /// <param name="matchingProperty"></param>
        /// <returns></returns>
        public static T GetExistingOrNew<T>(this DbContext db, T obj, string matchingProperty) where T : class
        {
            if (obj.GetType().GetProperty(matchingProperty) == null)
            {
                return obj;
            }

            DbSet<T>? someDbSet = db.Set<T>();
            if (someDbSet == null || someDbSet.GetType().GetProperty(matchingProperty) == null)
            {
                return obj;
            }


            if (someDbSet.Any(x => x.GetType().GetProperty(matchingProperty) == obj.GetType().GetProperty(matchingProperty)))
            {
                return someDbSet.Where(x => x.GetType().GetProperty(matchingProperty) == obj.GetType().GetProperty(matchingProperty)).First();
            }

            return obj;
        }
    }
}
