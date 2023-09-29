using BookStore.API.Repository.IRepository;

namespace BookStore.API.Repository
{
    public static class RepositoryInitilization
    {
        public static void ConfigRepositoryInitilize(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepositroy,BookRepository>();
            services.AddScoped<ISPBookRepository, SPBookRepository>();
        }
    }
}
