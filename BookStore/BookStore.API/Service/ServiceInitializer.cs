using BookStore.API.Service.Iservice;

namespace BookStore.API.Service
{
    public static class ServiceInitializer
    {

        public static void ConfigServiceInitilize(this IServiceCollection Service)
        {
            Service.AddScoped<IAuthorService, AuthorService>();
            Service.AddScoped<IBookService, BookService>();
            Service.AddScoped<ISpBookService,SpBookService>();
        }
    }
}
