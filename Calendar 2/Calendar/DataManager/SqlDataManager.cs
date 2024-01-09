using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public static class SqlDataManager
    {

        public static void Save(string name, List<string> data)
        {
            using (var context = new StringDbContext())
            {
                context.Database.EnsureCreated();

                foreach (string s in data)
                {
                    var entry = new DataEntry { Name=name, Content=s };
                    context.entries.Add(entry);
                }
                
                context.SaveChanges();
            }
        }

        public static List<string> Load(string name)
        {
            using (var context = new StringDbContext())
            {
                context.Database.EnsureCreated();

                var matching = context.entries.Where(item => item.Name == name).ToList();

                List<string> l = new List<string>();

                foreach (DataEntry d in matching)
                {
                    l.Add(d.Content);
                }

                return l;
            }
        }

        public static List<string> GetFiles()
        {
            using (var context = new StringDbContext())
            {
                context.Database.EnsureCreated();

                return context.entries.Select(item => item.Name)
                               .Distinct()
                               .ToList();

            }
        }
    }
}
