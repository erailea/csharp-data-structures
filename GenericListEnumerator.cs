using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace csharptests
{
    public class User
    {
        private int _Age;
        private string _Name;

        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }

    public class UserEnumerator2 : IEnumerable<User>
    {
        List<User> list = new List<User>();

        public UserEnumerator2(List<User> emplist)
        {
            list = emplist;
        }

        public IEnumerator<User> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Age > 50)
                {
                    yield return list[i];
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (GetEnumerator());
        }
    }

    public class UserEnumerator1 : IEnumerable<User>
    {
        List<User> list = new List<User>();

        public UserEnumerator1(List<User> emplist)
        {
            list = emplist;
        }

        public IEnumerator<User> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Age < 50)
                {
                    yield return list[i];
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (GetEnumerator());
        }
    }


    public class UserCollection
    {
        List<User> list = new List<User>();
        public List<User> Users
        {
            set
            {
                list = value;
            }

        }
        public UserCollection(List<User> cus)
        {
            this.Users = cus;
        }

        public UserEnumerator2 GetUserEnumerator2()
        {
            UserEnumerator2 enume = new UserEnumerator2(list);
            return enume;
        }
        public UserEnumerator1 GetUserEnumerator1()
        {
            UserEnumerator1 enume = new UserEnumerator1(list);
            return enume;
        }

    }
}
