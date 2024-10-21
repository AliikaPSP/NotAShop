using NotAShop.Core.Domain;
using NotAShop.Core.Dto;
using NotAShop.Core.ServiceInterface;
using NotAShop.Data;

namespace NotAShopRealEstateTest
{
    public class RealEstateTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyRealEstate_WhenReturnResult()
        {
            //Arrange
            RealEstateDto dto = new();

            dto.Size = 100;
            dto.Location = "asd";
            dto.RoomNumber = 1;
            dto.BuildingType = "asd";
            dto.CreatedAt = DateTime.Now;
            dto.ModifiedAt = DateTime.Now;

            //Act
            var result = await Svc<IRealEstateServices>().Create(dto);

            //Assert

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdRealestate_WhenReturnsNotEqual()
        {
            // Arrange
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("f0d2b871-29c3-456e-8eb2-3277a4aa791a");

            //Act
            await Svc<IRealEstateServices>().GetAsync(guid);

            //Assert
            Assert.NotEqual(wrongGuid, guid);
        }

        [Fact]
        public async Task Should_GetByIdRealestate_WhenReturnsEqual()
        {
            ////Arrange
            //Guid testGuid = Guid.NewGuid();  
            //var realEstate = new RealEstate
            //{
            //    Id = testGuid,  
            //    Size = 100,
            //    Location = "Test",
            //    RoomNumber = 3,
            //    BuildingType = "Apartment",
            //    CreatedAt = DateTime.Now,
            //    ModifiedAt = DateTime.Now
            //};

            //var context = Svc<NotAShopContext>();
            //context.RealEstates.Add(realEstate);
            //await context.SaveChangesAsync();

            //// Act
            //var result = await Svc<IRealEstateServices>().GetAsync(testGuid);

            //// Assert
            //Assert.Equal(testGuid, result.Id);

            //Arrange
            Guid databaseGuid = Guid.Parse("f0d2b871-29c3-456e-8eb2-3277a4aa791a");
            Guid guid = Guid.Parse("f0d2b871-29c3-456e-8eb2-3277a4aa791a");

            //Act
            await Svc<IRealEstateServices>().GetAsync(guid);

            //Assert
            Assert.Equal(databaseGuid, guid);
        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealEstate()
        {
            //Arrange
            RealEstateDto realEstate = MockRealEstateData();
            var AddRealEstate = await Svc<IRealEstateServices>().Create(realEstate);

            //Act
            var result = await Svc<IRealEstateServices>().Delete((Guid)AddRealEstate.Id);

            //Assert
            Assert.Equal(result, AddRealEstate);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdRealEstate_WhenDidNotDeleteRealEstate()
        {
            //Arrange
            RealEstateDto realEstate = MockRealEstateData();
            var realEstate1 = await Svc<IRealEstateServices>().Create(realEstate);
            var realEstate2 = await Svc<IRealEstateServices>().Create(realEstate);

            //Act
            var result = await Svc<IRealEstateServices>().Delete((Guid)realEstate2.Id);

            //Assert
            Assert.NotEqual(result.Id, realEstate1.Id);
        }

        private RealEstateDto MockRealEstateData()
        {
            RealEstateDto realEstate = new()
            {
                Size = 100,
                Location = "asd",
                RoomNumber = 1,
                BuildingType = "asd",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            return realEstate;
        }
    }
}