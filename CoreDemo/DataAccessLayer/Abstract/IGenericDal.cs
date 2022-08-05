using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //Generic interface'i dışarıdan bir Entity parametresi alır.
    //T burada Entity'e karşılık gelen değerdir.
    //ve where T : class diyerek bu T 'nin bir sınıfa ait bütün nitelikleri
    //kullanabileceğini belirtmiş oldum.

    public interface IGenericDal<T> where T : class
    {
        //Category ve Blog'a ait interfacelerdeki gibi, metod tanımlamaları yapacağım.
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetListAll();
        T GetById(int id);
        List<T> GetListAll(Expression<Func<T, bool>> filter);
    }
}
