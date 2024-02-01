using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using SampleWeb01.Controllers;
using SampleWeb01.Services;
using SampleWeb01.ViewModels;

namespace UT_TEST.Controller
{
    public class UserControllerTest: IDisposable
    {
        private UserController _controller;

        public UserControllerTest()
        {
            //Arrange
            Mock<IUserService> mock = new Mock<IUserService>();
            mock.Setup(mock => mock.create(new UserViewModel()))
                .Returns(new UserViewModel() { UserId =1,CompanyName ="test",Password ="pass",Remarks ="test"});

            _controller = new UserController(mock.Object);
        }
        public void Dispose()
        {
            // 完了後にアンマネージドリソースの処理したり.
            Console.WriteLine("disposed");
        }

        [Fact]
        public async void Index_Open()
        {

            //Act
            var result = _controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewData.Model);
        }

        [Fact]
        public void Create_Open()
        {
            //Act
            var result = _controller.Create();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var userModel = Assert.IsAssignableFrom<UserViewModel>(viewResult.ViewData.Model);
            Assert.Null(userModel.CompanyName);
            Assert.Null(userModel.Remarks);
        }

        [Fact]
        public void Create_Post()
        {
            //Arrange
            var userModel = new UserViewModel() { UserId = 1, CompanyName = "test", Password = "pass", Remarks = "test" };

            //Act
            var result = _controller.Create(userModel);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(viewResult.ViewName,"Detail");

            Assert.IsNotType<ViewResult>(result);

        }
    }
}
