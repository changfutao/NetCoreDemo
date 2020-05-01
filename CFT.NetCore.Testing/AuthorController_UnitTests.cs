using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoMapper;
using Moq;
using CFT.NetCore.WebAppDemo.Controllers;
using CFT.NetCore.WebAppDemo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CFT.NetCore.Testing
{
    public class AuthorController_UnitTests
    {
        private AuthorController _authorController;
        private Mock<IRepositoryWrapper> _mockRepositoryWrapper;
        private Mock<IMapper> _mockMapper;
        public AuthorController_UnitTests()
        {
            _mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            _mockMapper = new Mock<IMapper>();

            _authorController = new AuthorController(_mockRepositoryWrapper.Object, _mockMapper.Object);

            _authorController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
        }
        //[Fact]
        //public async Task Test_GetAllAuthors()
        //{

        //}
    }
}
