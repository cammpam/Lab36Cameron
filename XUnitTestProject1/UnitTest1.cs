using Lab36Cameron.Controllers;
using Lab36Cameron.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            var options = new DbContextOptionsBuilder<SongEntryDbContext>()
                .UseInMemoryDatabase(databaseName: "getStatusCode")
                .Options;

            //Arrange

            using (var context = new SongEntryDbContext(options))
            {
                var controller = new EntryController(context);


                //Act
                var result = controller.Get(5);
                {
                    ObjectResult sc = (ObjectResult)result;


                    //Assert
                    Assert.Equal(HttpStatusCode.OK, (HttpStatusCode)sc.StatusCode.Value);
                    //Assert.IsType(typeof(string), result);

                }
   lk         }
        }
    }
}
