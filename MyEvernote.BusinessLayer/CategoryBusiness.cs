using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEvernote.DataAccsessLayer.EF;
using MyEvernote.Entities;

namespace MyEvernote.BusinessLayer
{
    public class CategoryBusiness
    {
        private Repository<Kategori> repo_category = new Repository<Kategori>();

        public List<Kategori> SelectAllCategories()
        {
            return repo_category.List();
        }


     
    }
}
