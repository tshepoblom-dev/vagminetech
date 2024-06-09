using System.Globalization;

namespace MauiApp1.Models
{
    public class Category
    {
        public string idCategory { get; set; }
        public string strCategory { get; set; }
        public string strCategoryThumb { get; set; }    
        public string strCategoryDescription { get; set; }

    }
    public class CategoriesList
    { 
        public IEnumerable<Category> Categories { get; set;}
    }

}