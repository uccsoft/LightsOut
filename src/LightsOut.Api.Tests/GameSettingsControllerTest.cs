using LightsOut.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;

namespace LightsOut.Api.Tests
{
    public class GameSettingsControllerTest
    {
        private List<Models.GameSettings> getFakeData()
        {
            return new List<Models.GameSettings>()
            {
                new Models.GameSettings()
                {
                    Id = 1,
                    Name = "5 x 5",
                    BoardSize = 5
                },
                new Models.GameSettings()
                {
                    Id = 2,
                    Name = "8 x 8",
                    BoardSize = 8
                },
                new Models.GameSettings()
                {
                    Id = 3,
                    Name = "10 x 10",
                    BoardSize = 8
                }
            };
        }
        private Data.ApplicationDbContext createDbContext()
        {
            var options = new DbContextOptionsBuilder<Data.ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dbContext = new Data.ApplicationDbContext(options);

            dbContext.GameSettings.AddRange(getFakeData());
            dbContext.SaveChanges();

            return dbContext;
        }

        [Fact]
        public async void GetGameSettings_WhenCalled_ReturnsAllData()
        {
            //Arrange
            using(var context = createDbContext())
            {
                var controller = new GameSettingsController(context);

                //Act
                var actionResult = await controller.GetGameSettings();
                List<Models.GameSettings> list = actionResult.Value as List<Models.GameSettings>;

                //Assert
                Assert.Equal(list.Count, getFakeData().Count);

            }
        }

        [Fact]
        public async void GetGameSettingsById_WhenCalled_ReturnsCorrectItem()
        {
            //Arrange
            using (var context = createDbContext())
            {
                var controller = new GameSettingsController(context);
                int id = 1;
                //Act
                var actionResult = await controller.GetGameSettings(id);
                Models.GameSettings result = actionResult.Value as Models.GameSettings;

                var item = getFakeData().Find(x => x.Id == id);

                //Assert
                Assert.Equal(result.Name, item.Name);
            }
        }

        [Fact]
        public async void GetGameSettingsById_WhenCalled_ReturnsNoItem()
        {
            //Arrange
            using (var context = createDbContext())
            {
                var controller = new GameSettingsController(context);
                int id = 999;
                //Act
                var actionResult = await controller.GetGameSettings(id);
                Models.GameSettings result = actionResult.Value as Models.GameSettings;

                //Assert
                Assert.Null(result);
            }
        }
    }
}
