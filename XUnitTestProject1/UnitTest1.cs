using Lab36Cameron.Controllers;
using Lab36Cameron.Data;
using Lab36Cameron.Models;
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
            }



        }

        [Fact]
        public void TestAudio()
        {
            SongItem audioTest = new SongItem();
            audioTest.Audio = true;
            bool testBool = audioTest.Audio;
            Assert.Equal(audioTest.Audio, true);
        }


        [Fact]
        public void TestTile()
        {
            Contributors TitleTest = new Contributors();
            TitleTest.Title = "New Song";
            string testString = TitleTest.Title;
            Assert.Equal(TitleTest.Title, "New Song");
        }


        [Fact]
        public void TestCompletion()
        {
            SongItem TestCompletion = new SongItem();
            TestCompletion.IsComplete = false;
            bool TestBool = TestCompletion.IsComplete;
            Assert.Equal(TestCompletion.IsComplete, false);
        }


    }
}
