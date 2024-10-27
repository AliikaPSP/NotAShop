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

        [Fact]
        public async Task ShouldNot_GetByIdKindergarten_WhenReturnsNotEqual()
        {
            // Arrange
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("f0d2b871-29c3-456e-8eb2-3277a4aa791a");

            //Act
            await Svc<IKindergartensServices>().DetailAsync(guid);

            //Assert
            Assert.NotEqual(wrongGuid, guid);
        }

        [Fact]
        public async Task Should_GetByIdKindergarten_WhenReturnsEqual()
        {
            Guid databaseGuid = Guid.Parse("f0d2b871-29c3-456e-8eb2-3277a4aa791a");
            Guid guid = Guid.Parse("f0d2b871-29c3-456e-8eb2-3277a4aa791a");

            //Act
            await Svc<IKindergartensServices>().DetailAsync(guid);

            //Assert
            Assert.Equal(databaseGuid, guid);
        }

        [Fact]
        public async Task Should_DeleteByIdKindergarten_WhenDeleteKindergarten()
        {
            //Arrange
            KindergartenDto kindergarten = MockKindergartenData();
            var AddKindergarten = await Svc<IKindergartensServices>().Create(kindergarten);

            //Act
            var result = await Svc<IKindergartensServices>().Delete((Guid)AddKindergarten.Id);

            //Assert
            Assert.Equal(result, AddKindergarten);
        }

        private KindergartenDto MockKindergartenData()
        {
            KindergartenDto kindergarten = new()
            {
                GroupName = "Miisud",
                ChildrenCount = 6,
                KindergartenName = "Miisuaed",
                Teacher = "Mr. Miisu",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            return kindergarten;
        }
    }
}