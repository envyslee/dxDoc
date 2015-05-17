using System;
using System.Collections.Generic;
using System.Linq;

namespace dxy.Common
{
    public class Group<T> : List<T>
    {
        public Group(int key, IEnumerable<T> items): base(items)
        {
            this.Key = key;
        }

        public int Key { get; set; }

        public static List<Group<T>> GetItemGroups<T>(IEnumerable<T> itemList, Func<T, string> getKeyFunc)
        {
            IEnumerable<Group<T>> groupList = from item in itemList
                                              group item by getKeyFunc(item) into g
                                              orderby int.Parse(g.Key) ascending 
                                              select new Group<T>(int.Parse( g.Key), g);

            return groupList.ToList();
        }

    }
}
