namespace BookStore.API.Middleware
{
    public static class GlobleExceptionHandlerMiddlewair
    {
        public static  void GlobleExceptionHandler(this IApplicationBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 404 && !ctx.Response.HasStarted)
                {
                    Console.WriteLine("404");
                    ctx.Response.Redirect("/api/Authors/Get");
                }
            });
        }
    }
}
