using Merino.Data;
using Microsoft.EntityFrameworkCore;
using yuta_SampleWeb01.Data;
using yuta_SampleWeb01.Models;
using static yuta_SampleWeb01.Const.Const;

namespace yuta_SampleWeb01.ViewModels.SeedData
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new yuta_SampleWeb01Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<yuta_SampleWeb01Context>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }
                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Rating = "R",
                        Price = 7.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Rating = "R",
                        Price = 8.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Rating = "R",
                        Price = 9.99M
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Rating = "R",
                        Price = 3.99M
                    }
                );

                if (context.TUser.Any())
                {
                    return;   // DB has been seeded
                }
                context.TUser.AddRange(
                    new TUser
                    {
                        UserId = 1,
                        Password = "password",
                        DeletedFlg = "0",
                        CreatePgmId = "Seed",
                        CreateUserId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = "Seed",
                        UpdateDate = DateTime.Now,
                    }
                    );

                if (context.TUserCompany.Any())
                {
                    return;   // DB has been seeded
                }
                context.TUserCompany.AddRange(
                    new TUserCompany
                    {
                        UserId = 1,
                        CompanyName = "Test",
                        Remarks = "Test",
                        CreatePgmId = "Seed",
                        CreateUserId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = "Seed",
                        UpdateDate = DateTime.Now,
                    }
                    );

                if (context.TDataA.Any())
                {
                    return;   // DB has been seeded
                }
                context.TDataA.AddRange(
                    new TDataA
                    {
                        userId = 1,
                        dataCls = DataCls.DataA,
                        status = Status.Entry,
                        periodDate = DateTime.Now,
                        downloadFlg = false,
                        DeletedFlg = "0",
                        CreatePgmId = "Seed",
                        CreateUserId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = "Seed",
                        UpdateDate = DateTime.Now,
                    },
                    new TDataA
                    {
                        userId = 1,
                        dataCls = DataCls.DataB,
                        status = Status.Entry,
                        periodDate = DateTime.Now,
                        downloadFlg = false,
                        DeletedFlg = "0",
                        CreatePgmId = "Seed",
                        CreateUserId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = "Seed",
                        UpdateDate = DateTime.Now,
                    },
                    new TDataA
                    {
                        userId = 1,
                        dataCls = DataCls.DataC,
                        status = Status.Entry,
                        periodDate = DateTime.Now,
                        downloadFlg = false,
                        DeletedFlg = "0",
                        CreatePgmId = "Seed",
                        CreateUserId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = "Seed",
                        UpdateDate = DateTime.Now,
                    },
                    new TDataA
                    {
                        userId = 1,
                        dataCls = DataCls.DataA,
                        status = Status.Registration,
                        periodDate = DateTime.Now,
                        downloadFlg = false,
                        DeletedFlg = "0",
                        CreatePgmId = "Seed",
                        CreateUserId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = "Seed",
                        UpdateDate = DateTime.Now,
                    },
                    new TDataA
                    {
                        userId = 1,
                        dataCls = DataCls.DataA,
                        status = Status.Registration,
                        periodDate = DateTime.Now,
                        downloadFlg = false,
                        DeletedFlg = "1",
                        CreatePgmId = "Seed",
                        CreateUserId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = "Seed",
                        UpdateDate = DateTime.Now,
                    },
                    new TDataA
                    {
                        userId = 1,
                        dataCls = DataCls.DataA,
                        status = Status.completion,
                        periodDate = DateTime.Now,
                        downloadFlg = false,
                        DeletedFlg = "1",
                        CreatePgmId = "Seed",
                        CreateUserId = "Seed",
                        CreateDate = DateTime.Now,
                        UpdatePgmId = "Seed",
                        UpdateUserId = "Seed",
                        UpdateDate = DateTime.Now,
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
