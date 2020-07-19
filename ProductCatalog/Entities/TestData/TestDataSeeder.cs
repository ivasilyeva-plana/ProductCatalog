using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProductCatalog.Entities.TestData
{
    public class TestDataSeeder : ISeeder<Context>
    {
        public void Seed(Context context)
        {
            context.ProductCategories.AddRange(
                new ProductCategory {Name = "Молочная продукция"},
                new ProductCategory {Name = "Выпечка"});

            context.Products.AddRange(
                new Product
                {
                    ProductCategoryId = 1,
                    Name = "Молоко",
                    Specification = JsonConvert.SerializeObject(new JObject
                    {
                        {"Вес", "500г"},
                        {"Тара", "Стекляная бутылка"}
                    })
                },
                new Product {ProductCategoryId = 1, Name = "Кефир"},
                new Product
                {
                    ProductCategoryId = 2,
                    Name = "Плюшка",
                    Specification = JsonConvert.SerializeObject(new JObject
                    {
                        {"Вес", "500г"},
                        {"Состав", new JArray {"Мука", "Масло", "Яйца", "Сахар"}}
                    })
                }
            );

            context.Persons.AddRange(
                new Person {Login = "user", Password = "user", Role = Role.User.ToString()},
                new Person {Login = "admin", Password = "admin", Role = Role.Admin.ToString()});

            context.SaveChanges();
        }
    }
}
