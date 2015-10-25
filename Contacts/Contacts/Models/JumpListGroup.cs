using System.Collections.Generic;

namespace Contacts.Models
{
    public class JumpListGroup<T> : List<object>
    {
        /// <summary>
        /// Key that represents the group of objects and used as group header.
        /// </summary>
        public object Key { get; set; }

        public new IEnumerator<object> GetEnumerator()
        {
            return base.GetEnumerator();
        }
    }
}