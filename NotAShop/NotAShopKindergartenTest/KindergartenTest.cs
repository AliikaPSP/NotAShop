using Microsoft.AspNetCore.Http;
using NotAShop.Core.Domain;
using NotAShop.Core.Dto;
using NotAShop.Core.ServiceInterface;
using NotAShop.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NotAShopKindergartenTest
{
    public class KindergartenTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddKindergarten_WhenReturnResult()
        {
            //Arrange
            KindergartenDto dto = new();

            dto.GroupName = "Kiisud";
            dto.ChildrenCount = 5;
            dto.KindergartenName = "Kiisuaed";
            dto.Teacher = "Mrs. Kiisu";
            dto.CreatedAt = DateTime.Now;
            dto.UpdatedAt = DateTime.Now;

            //Act
            var result = await Svc<IKindergartensServices>().Create(dto);

            //Assert

            Assert.NotNull(result);
        }
    }
}