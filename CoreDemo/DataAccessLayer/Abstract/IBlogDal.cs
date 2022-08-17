using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        //Bu metod sadece Blog'lara özel olduğu için bu interface'de tanımladım :
        List<Blog> GetListWithCategory();  
        List<Blog> GetListWithCategoryByWriter(int id);  
    }
}
